using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sakamoto.TCC2.CSU.EventStore.Application.Interfaces;

namespace Sakamoto.TCC2.CSU.EventStore.Application.Controller
{
    [Produces("application/json")]
    public class EventStoreController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly IEventStoreRepository _eventStoreRepository;

        public EventStoreController(IEventStoreRepository eventStoreRepository)
        {
            _eventStoreRepository = eventStoreRepository;
        }

        // GET
        [HttpGet]
        [Route("stored-event/{aggregateid:guid}")]
        public async Task<IActionResult> GetStoredEvent(Guid? aggregateId)
        {
            if (aggregateId == null)
                return NotFound();

            var events = _eventStoreRepository.EventsByAggregate(aggregateId.Value);
            if (events.Any())
                return Ok(events);
            return NotFound(events);
        }

        // GET
        [HttpGet]
        [Route("stored-events")]
        public async Task<IActionResult> GetStoredEvents()
        {
            var events = _eventStoreRepository.All();
            if (events.Any())
                return Ok(events);
            return NotFound(events);
        }
    }
}