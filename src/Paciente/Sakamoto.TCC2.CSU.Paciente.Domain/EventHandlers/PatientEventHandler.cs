using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Sakamoto.TCC2.CSU.Patients.Domain.Events;

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
        public Task Handle(PatientAddressUpdatedEvent notification, CancellationToken cancellationToken)
        {
            // TODO SEND PATIENT ADDRESS UPDATED EVENT MESSAGE

            return Task.CompletedTask;
        }

        public Task Handle(PatientDeactivatedEvent notification, CancellationToken cancellationToken)
        {
            // TODO SEND PATIENT DEACTIVATED EVENT MESSAGE

            return Task.CompletedTask;
        }

        public Task Handle(PatientEmailUpdatedEvent notification, CancellationToken cancellationToken)
        {
            // TODO SEND PATIENT EMAIL UPDATED EVENT MESSAGE

            return Task.CompletedTask;
        }

        public Task Handle(PatientHeartRateUpdatedEvent notification, CancellationToken cancellationToken)
        {
            // TODO SEND PATIENT HEART RATE UPDATED EVENT MESSAGE

            return Task.CompletedTask;
        }

        public Task Handle(PatientPhoneUpdatedEvent notification, CancellationToken cancellationToken)
        {
            // TODO SEND PATIENT PHONE UPDATED EVENT MESSAGE

            return Task.CompletedTask;
        }

        public Task Handle(PatientPhotoUpdatedEvent notification, CancellationToken cancellationToken)
        {
            // TODO SEND PATIENT PHOTO UPDATED EVENT MESSAGE

            return Task.CompletedTask;
        }

        public Task Handle(PatientRegisteredEvent notification, CancellationToken cancellationToken)
        {
            // TODO SEND PATIENT REGISTERED EVENT MESSAGE

            return Task.CompletedTask;
        }
    }
}