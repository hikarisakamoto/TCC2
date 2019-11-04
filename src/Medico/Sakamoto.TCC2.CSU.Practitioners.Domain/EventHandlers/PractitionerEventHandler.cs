using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Newtonsoft.Json;
using Sakamoto.TCC2.CSU.Domain.Core.Events;
using Sakamoto.TCC2.CSU.Practitioners.Domain.Events;
using Sakamoto.TCC2.CSU.Practitioners.Domain.Interfaces;

namespace Sakamoto.TCC2.CSU.Practitioners.Domain.EventHandlers
{
    public class PractitionerEventHandler :
        INotificationHandler<PractitionerRegisteredEvent>,
        INotificationHandler<PractitionerDeactivatedEvent>,
        INotificationHandler<PractitionerPhoneUpdatedEvent>,
        INotificationHandler<PractitionerEmailUpdatedEvent>
    {
        private readonly IMessageEventHandler _eventHandler;

        public PractitionerEventHandler(IMessageEventHandler eventHandler)
        {
            _eventHandler = eventHandler;
        }
        // TODO - REMOVE DEPENDENCY FROM JSON CONVERT

        public Task Handle(PractitionerDeactivatedEvent @event, CancellationToken cancellationToken)
        {
            var data = JsonConvert.SerializeObject(@event);
            _eventHandler.SendMessage(new StoredEvent(@event, data, "Sakamoto"));

            return Task.CompletedTask;
        }

        public Task Handle(PractitionerEmailUpdatedEvent @event, CancellationToken cancellationToken)
        {
            var data = JsonConvert.SerializeObject(@event);
            _eventHandler.SendMessage(new StoredEvent(@event, data, "Sakamoto"));

            return Task.CompletedTask;
        }

        public Task Handle(PractitionerPhoneUpdatedEvent @event, CancellationToken cancellationToken)
        {
            var data = JsonConvert.SerializeObject(@event);
            _eventHandler.SendMessage(new StoredEvent(@event, data, "Sakamoto"));

            return Task.CompletedTask;
        }

        public Task Handle(PractitionerRegisteredEvent @event, CancellationToken cancellationToken)
        {
            var data = JsonConvert.SerializeObject(@event);
            _eventHandler.SendMessage(new StoredEvent(@event, data, "Sakamoto"));

            return Task.CompletedTask;
        }
    }
}