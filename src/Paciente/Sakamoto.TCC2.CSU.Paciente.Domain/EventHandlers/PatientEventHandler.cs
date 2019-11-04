using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Newtonsoft.Json;
using Sakamoto.TCC2.CSU.Domain.Core.Events;
using Sakamoto.TCC2.CSU.Patients.Domain.Events;
using Sakamoto.TCC2.CSU.Patients.Domain.Interfaces;

namespace Sakamoto.TCC2.CSU.Patients.Domain.EventHandlers
{
    public class PatientEventHandler : INotificationHandler<PatientRegisteredEvent>
        , INotificationHandler<PatientDeactivatedEvent>
        , INotificationHandler<PatientAddressUpdatedEvent>
        , INotificationHandler<PatientEmailUpdatedEvent>
        , INotificationHandler<PatientPhoneUpdatedEvent>
        , INotificationHandler<PatientPhotoUpdatedEvent>
        , INotificationHandler<PatientHeartRateUpdatedEvent>
    {
        private readonly IMessageEventHandler _eventHandler;

        public PatientEventHandler(IMessageEventHandler eventHandler)
        {
            _eventHandler = eventHandler;
        }

        // TODO - REMOVE DEPENDENCY FROM JSON CONVERT

        public Task Handle(PatientAddressUpdatedEvent @event, CancellationToken cancellationToken)
        {
            var data = JsonConvert.SerializeObject(@event);
            _eventHandler.SendMessage(new StoredEvent(@event, data, "Sakamoto"));

            return Task.CompletedTask;
        }

        public Task Handle(PatientDeactivatedEvent @event, CancellationToken cancellationToken)
        {
            var data = JsonConvert.SerializeObject(@event);
            _eventHandler.SendMessage(new StoredEvent(@event, data, "Sakamoto"));

            return Task.CompletedTask;
        }

        public Task Handle(PatientEmailUpdatedEvent @event, CancellationToken cancellationToken)
        {
            var data = JsonConvert.SerializeObject(@event);
            _eventHandler.SendMessage(new StoredEvent(@event, data, "Sakamoto"));

            return Task.CompletedTask;
        }

        public Task Handle(PatientHeartRateUpdatedEvent @event, CancellationToken cancellationToken)
        {
            var data = JsonConvert.SerializeObject(@event);
            _eventHandler.SendMessage(new StoredEvent(@event, data, "Sakamoto"));

            return Task.CompletedTask;
        }

        public Task Handle(PatientPhoneUpdatedEvent @event, CancellationToken cancellationToken)
        {
            var data = JsonConvert.SerializeObject(@event);
            _eventHandler.SendMessage(new StoredEvent(@event, data, "Sakamoto"));

            return Task.CompletedTask;
        }

        public Task Handle(PatientPhotoUpdatedEvent @event, CancellationToken cancellationToken)
        {
            var data = JsonConvert.SerializeObject(@event);
            _eventHandler.SendMessage(new StoredEvent(@event, data, "Sakamoto"));

            return Task.CompletedTask;
        }

        public Task Handle(PatientRegisteredEvent @event, CancellationToken cancellationToken)
        {
            var data = JsonConvert.SerializeObject(@event);
            _eventHandler.SendMessage(new StoredEvent(@event, data, "Sakamoto"));

            return Task.CompletedTask;
        }
    }
}