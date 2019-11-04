using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Newtonsoft.Json;
using Sakamoto.TCC2.CSU.Domain.Core.Events;
using Sakamoto.TCC2.CSU.MedicalRecord.Domain.Events;
using Sakamoto.TCC2.CSU.MedicalRecord.Domain.Interfaces;

namespace Sakamoto.TCC2.CSU.MedicalRecord.Domain.EventHandlers
{
    public class MedicalReportEventHandler :
        INotificationHandler<MedicalReportAddedEvent>,
        INotificationHandler<MedicalReportWithImageAddedEvent>,
        INotificationHandler<MedicalReportRemovedEvent>
    {
        private readonly IMessageEventHandler _eventHandler;

        public MedicalReportEventHandler(IMessageEventHandler eventHandler)
        {
            _eventHandler = eventHandler;
        }
        // TODO - REMOVE DEPENDENCY FROM JSON CONVERT


        public Task Handle(MedicalReportAddedEvent @event, CancellationToken cancellationToken)
        {
            var data = JsonConvert.SerializeObject(@event);
            _eventHandler.SendMessage(new StoredEvent(@event, data, "Sakamoto"));

            return Task.CompletedTask;
        }

        public Task Handle(MedicalReportRemovedEvent @event, CancellationToken cancellationToken)
        {
            var data = JsonConvert.SerializeObject(@event);
            _eventHandler.SendMessage(new StoredEvent(@event, data, "Sakamoto"));

            return Task.CompletedTask;
        }

        public Task Handle(MedicalReportWithImageAddedEvent @event, CancellationToken cancellationToken)
        {
            var data = JsonConvert.SerializeObject(@event);
            _eventHandler.SendMessage(new StoredEvent(@event, data, "Sakamoto"));

            return Task.CompletedTask;
        }
    }
}