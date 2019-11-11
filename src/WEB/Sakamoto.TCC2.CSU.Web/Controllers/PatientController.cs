using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Sakamoto.TCC2.CSU.Web.Data;
using Sakamoto.TCC2.CSU.Web.Models.Patients;

namespace Sakamoto.TCC2.CSU.Web.Controllers
{
    public class PatientController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly CSUContext _context;

        public PatientController(CSUContext context, IHttpClientFactory clientFactory)
        {
            _context = context;
            _clientFactory = clientFactory;
        }

        // TODO
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null) return NotFound();

            var request = new HttpRequestMessage(HttpMethod.Get,
                $"https://sakamoto-csu-patient.azurewebsites.net/patient-basic-information/{id}");

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (!response.IsSuccessStatusCode) return NotFound();

            var responseStream = await response.Content.ReadAsStringAsync();
            var patientViewModel = JsonConvert.DeserializeObject<PatientViewModel>(responseStream);

            if (patientViewModel == null) return NotFound();
            return View(patientViewModel);
        }

        // GET: Patient/HeartRate/5
        public async Task<IActionResult> HeartRate(Guid? id)
        {
            if (id == null) return NotFound();

            var request = new HttpRequestMessage(HttpMethod.Get,
                $"https://sakamoto-csu-patient.azurewebsites.net/patient-information/{id}");

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (!response.IsSuccessStatusCode) return NotFound();

            var responseStream = await response.Content.ReadAsStringAsync();
            var patientViewModel = JsonConvert.DeserializeObject<PatientViewModel>(responseStream);

            if (patientViewModel == null) return NotFound();

            var heartRateViewModel = new UpdatePatientHeartRateViewModel
            {
                Id = patientViewModel.Id,
                HeartRate = patientViewModel.HeartRate
            };

            return View(heartRateViewModel);
        }

        // POST: Patient/HeartRate/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> HeartRate(Guid id, UpdatePatientHeartRateViewModel patientViewModel)
        {
            if (id != patientViewModel.Id) return NotFound();

            if (!ModelState.IsValid) return View(patientViewModel);

            var client = _clientFactory.CreateClient();
            var response =
                await client.PostAsync(
                    "https://sakamoto-csu-patient.azurewebsites.net//patient-management-update-heartrate",
                    new StringContent(JsonConvert.SerializeObject(patientViewModel), Encoding.UTF8,
                        "application/json"));

            if (response.IsSuccessStatusCode)
                return RedirectToAction(nameof(Index));

            return BadRequest();
        }

        // GET: Patient
        public async Task<IActionResult> Index()
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
                "https://sakamoto-csu-patient.azurewebsites.net/patients");

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (!response.IsSuccessStatusCode) return BadRequest();

            var responseStream = await response.Content.ReadAsStringAsync();
            var patientInformation =
                JsonConvert.DeserializeObject<List<PatientBasicInformationViewModel>>(responseStream);

            return View(patientInformation);
        }

        // GET: Patient/Register
        public IActionResult Register()
        {
            return View();
        }

        // POST: Patient/Register
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterNewPatientViewModel patientViewModel)
        {
            if (!ModelState.IsValid) return View(patientViewModel);

            var client = _clientFactory.CreateClient();
            var response = await client.PostAsync("https://sakamoto-csu-patient.azurewebsites.net/patient-register",
                new StringContent(JsonConvert.SerializeObject(patientViewModel), Encoding.UTF8, "application/json"));


            if (!response.IsSuccessStatusCode) return BadRequest(response.StatusCode);
            return RedirectToAction(nameof(Index));
        }

        // GET: Patient/UpdateAddress/5
        public async Task<IActionResult> UpdateAddress(Guid? id)
        {
            if (id == null) return NotFound();

            var request = new HttpRequestMessage(HttpMethod.Get,
                $"https://sakamoto-csu-patient.azurewebsites.net/patient-information/{id}");

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (!response.IsSuccessStatusCode) return NotFound();

            var responseStream = await response.Content.ReadAsStringAsync();
            var patientViewModel = JsonConvert.DeserializeObject<PatientViewModel>(responseStream);

            if (patientViewModel == null) return NotFound();

            var addressViewModel = new UpdatePatientAddressViewModel
            {
                Id = patientViewModel.Id,
                City = patientViewModel.Address.City,
                District = patientViewModel.Address.District,
                Number = patientViewModel.Address.Number,
                Observation = patientViewModel.Address.Observation,
                PostalCode = patientViewModel.Address.PostalCode,
                State = patientViewModel.Address.State,
                Street = patientViewModel.Address.Street
            };

            return View(addressViewModel);
        }

        // POST: Patient/UpdateAddress/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateAddress(Guid id, UpdatePatientAddressViewModel patientViewModel)
        {
            if (id != patientViewModel.Id) return NotFound();

            if (!ModelState.IsValid) return View(patientViewModel);

            var client = _clientFactory.CreateClient();
            var response =
                await client.PostAsync(
                    "https://sakamoto-csu-patient.azurewebsites.net/patient-management-update-address",
                    new StringContent(JsonConvert.SerializeObject(patientViewModel), Encoding.UTF8,
                        "application/json"));

            if (response.IsSuccessStatusCode)
                return RedirectToAction(nameof(Index));

            return BadRequest();
        }
    }
}