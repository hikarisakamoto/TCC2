using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Sakamoto.TCC2.CSU.Web.Models.MedicalRecord;
using Sakamoto.TCC2.CSU.Web.Models.Patients;
using Sakamoto.TCC2.CSU.Web.Models.Practitioners;

namespace Sakamoto.TCC2.CSU.Web.Controllers
{
    public class MedicalRecordController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;

        public MedicalRecordController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        // GET: MedicalRecord/AddMedicalRecord
        public async Task<IActionResult> AddMedicalRecord()
        {
            var patientInformation = await GetPatients();
            var patients = patientInformation.Select(p => new SelectListItem
            {
                Text = p.FullName,
                Value = p.Id.ToString()
            }).ToList();

            var practitionerInformation = await GetPractitioners();
            var practitioners = practitionerInformation.Select(p => new SelectListItem
            {
                Value = p.Id.ToString(),
                Text = $"{p.CRM} - {p.FullName}"
            });

            ViewBag.Patients = patients;
            ViewBag.Practitioners = practitioners;
            return View();
        }

        // POST: MedicalRecord/AddMedicalRecord
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddMedicalRecord(AddNewMedicalRecordViewModel medicalRecordViewModel)
        {
            if (!ModelState.IsValid) return View(medicalRecordViewModel);

            var client = _clientFactory.CreateClient();
            var response = await client.PostAsync(
                "https://csu-medicalrecord.azurewebsites.net/medical-record-simple",
                new StringContent(JsonConvert.SerializeObject(medicalRecordViewModel), Encoding.UTF8,
                    "application/json"));


            if (!response.IsSuccessStatusCode) return BadRequest(response.StatusCode);
            return RedirectToAction(nameof(Index));
        }

        // GET: MedicalRecord/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null) return NotFound();

            var request = new HttpRequestMessage(HttpMethod.Get,
                $"https://csu-medicalrecord.azurewebsites.net/medical-record/{id}");

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (!response.IsSuccessStatusCode) return NotFound();

            var responseStream = await response.Content.ReadAsStringAsync();
            var medicalRecord = JsonConvert.DeserializeObject<MedicalRecordViewModel>(responseStream);

            if (medicalRecord == null) return NotFound();
            return View(medicalRecord);
        }

        private async Task<List<PatientBasicInformationViewModel>> GetPatients()
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
                "https://csu-patient.azurewebsites.net/patients");

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (!response.IsSuccessStatusCode) return new List<PatientBasicInformationViewModel>();

            var responseStream = await response.Content.ReadAsStringAsync();
            var patientInformation =
                JsonConvert.DeserializeObject<List<PatientBasicInformationViewModel>>(responseStream);
            return patientInformation;
        }

        private async Task<List<PractitionerViewModel>> GetPractitioners()
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
                "https://csu-practitioner.azurewebsites.net/practitioners");

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (!response.IsSuccessStatusCode) return new List<PractitionerViewModel>();

            var responseStream = await response.Content.ReadAsStringAsync();
            var practitionerViewModels =
                JsonConvert.DeserializeObject<List<PractitionerViewModel>>(responseStream);
            return practitionerViewModels;
        }

        // GET: MedicalRecord
        public async Task<IActionResult> Index()
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
                "https://csu-medicalrecord.azurewebsites.net/medical-records");

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (!response.IsSuccessStatusCode) return BadRequest();

            var responseStream = await response.Content.ReadAsStringAsync();
            var medicalRecord =
                JsonConvert.DeserializeObject<List<MedicalRecordViewModel>>(responseStream);

            return View(medicalRecord);
        }
    }
}