using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Sakamoto.TCC2.CSU.MedicalRecord.Domain.Events;

namespace Sakamoto.TCC2.CSU.MedicalRecord.Domain.EventHandlers
{
    public class MedicalReportEventHandler :
        INotificationHandler<MedicalReportAddedEvent>,
        INotificationHandler<MedicalReportWithImageAddedEvent>,
        INotificationHandler<MedicalReportRemovedEvent>
    {
        public Task Handle(MedicalReportAddedEvent notification, CancellationToken cancellationToken)
        {
            // TODO SEND MESSAGE

            return Task.CompletedTask;
        }

        public Task Handle(MedicalReportRemovedEvent notification, CancellationToken cancellationToken)
        {
            // TODO SEND MESSAGE

            return Task.CompletedTask;
        }

        public Task Handle(MedicalReportWithImageAddedEvent notification, CancellationToken cancellationToken)
        {
            // TODO SEND MESSAGE

            return Task.CompletedTask;
        }
    }
}