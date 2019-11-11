using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Sakamoto.TCC2.CSU.Web.Models.Practitioners;

namespace Sakamoto.TCC2.CSU.Web.Controllers
{
    public class PractitionerController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;


        public PractitionerController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        // GET: Practitioner/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null) return NotFound();

            var request = new HttpRequestMessage(HttpMethod.Get,
                $"https://sakamoto-csu-practitioner.azurewebsites.net/practitioner-information/{id}");

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (!response.IsSuccessStatusCode) return NotFound();

            var responseStream = await response.Content.ReadAsStringAsync();
            var patientViewModel = JsonConvert.DeserializeObject<PractitionerViewModel>(responseStream);

            if (patientViewModel == null) return NotFound();
            return View(patientViewModel);
        }

        // GET: Practitioner
        public async Task<IActionResult> Index()
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
                "https://sakamoto-csu-practitioner.azurewebsites.net/practitioners");

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (!response.IsSuccessStatusCode) return BadRequest();

            var responseStream = await response.Content.ReadAsStringAsync();
            var practitionerViewModels =
                JsonConvert.DeserializeObject<List<PractitionerViewModel>>(responseStream);

            return View(practitionerViewModels);
        }

        // GET: Practitioner/Register
        public IActionResult Register()
        {
            return View();
        }

        // POST: Practitioner/Register
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterNewPractitionerViewModel practitionerViewModel)
        {
            if (!ModelState.IsValid) return View(practitionerViewModel);

            var client = _clientFactory.CreateClient();
            var response = await client.PostAsync(
                "https://sakamoto-csu-practitioner.azurewebsites.net/practitioner-register",
                new StringContent(JsonConvert.SerializeObject(practitionerViewModel), Encoding.UTF8,
                    "application/json"));


            if (!response.IsSuccessStatusCode) return BadRequest(response.StatusCode);
            return RedirectToAction(nameof(Index));
        }

        // GET: Practitioner/UpdateEmail/5
        public async Task<IActionResult> UpdateEmail(Guid? id)
        {
            if (id == null) return NotFound();

            var request = new HttpRequestMessage(HttpMethod.Get,
                $"https://sakamoto-csu-practitioner.azurewebsites.net/practitioner-information/{id}");

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (!response.IsSuccessStatusCode) return NotFound();

            var responseStream = await response.Content.ReadAsStringAsync();
            var practitionerViewModel = JsonConvert.DeserializeObject<PractitionerViewModel>(responseStream);

            if (practitionerViewModel == null) return NotFound();

            var addressViewModel = new UpdatePractitionerEmailViewModel
            {
                Id = practitionerViewModel.Id,
                CRM = practitionerViewModel.CRM,
                Email = practitionerViewModel.Email
            };

            return View(addressViewModel);
        }

        // POST: Practitioner/UpdateEmail/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateEmail(Guid id, UpdatePractitionerEmailViewModel practitionerViewModel)
        {
            if (id != practitionerViewModel.Id) return NotFound();

            if (!ModelState.IsValid) return View(practitionerViewModel);

            var client = _clientFactory.CreateClient();
            var response =
                await client.PostAsync(
                    "https://sakamoto-csu-practitioner.azurewebsites.net/practitioner-management-update-email",
                    new StringContent(JsonConvert.SerializeObject(practitionerViewModel), Encoding.UTF8,
                        "application/json"));

            if (response.IsSuccessStatusCode)
                return RedirectToAction(nameof(Index));

            return BadRequest();
        }
    }
}