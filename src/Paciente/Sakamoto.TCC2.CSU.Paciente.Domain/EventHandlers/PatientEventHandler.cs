using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Sakamoto.TCC2.CSU.Patients.Domain.Events;

namespace Sakamoto.TCC2.CSU.Patients.Domain.EventHandlers
{
    public class PatientEventHandler : INotificationHandler<PatientRegisteredEvent>,
        INotificationHandler<PatientDeactivatedEvent>, INotificationHandler<PatientUpdatedEvent>
    {
        public Task Handle(PatientDeactivatedEvent notification, CancellationToken cancellationToken)
        {
            // TODO SEND PATIENT DEACTIVATED EVENT MESSAGE

            return Task.CompletedTask;
        }

        public Task Handle(PatientRegisteredEvent notification, CancellationToken cancellationToken)
        {
            // TODO SEND PATIENT REGISTERED EVENT MESSAGE

            return Task.CompletedTask;
        }

        public Task Handle(PatientUpdatedEvent notification, CancellationToken cancellationToken)
        {
            // TODO SEND PATIENT UPDATED EVENT MESSAGE

            return Task.CompletedTask;
        }
    }
}