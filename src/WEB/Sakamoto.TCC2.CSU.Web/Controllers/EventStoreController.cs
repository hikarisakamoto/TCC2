using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Sakamoto.TCC2.CSU.Web.Models.EventStore;

namespace Sakamoto.TCC2.CSU.Web.Controllers
{
    public class EventStoreController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;

        public EventStoreController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        // GET: EventStore/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null) return NotFound();

            var request = new HttpRequestMessage(HttpMethod.Get,
                $"https://sakamoto-csu-eventstore.azurewebsites.net​/stored-event​/{id}");

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (!response.IsSuccessStatusCode) return NotFound();

            var responseStream = await response.Content.ReadAsStringAsync();
            var storedEvent = JsonConvert.DeserializeObject<IEnumerable<StoredEventViewModel>>(responseStream);

            if (storedEvent == null) return NotFound();
            return View(storedEvent);
        }

        // GET: EventStore
        public async Task<IActionResult> Index()
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
                "https://csu-eventstore.azurewebsites.net/stored-events");

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (!response.IsSuccessStatusCode) return BadRequest();

            var responseStream = await response.Content.ReadAsStringAsync();
            var aggreteIds =
                JsonConvert.DeserializeObject<List<Guid>>(responseStream);

            return View(aggreteIds);
        }
    }
}