using System;
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

        public Task Handle(PatientAddressUpdatedEvent notification, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task Handle(PatientEmailUpdatedEvent notification, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task Handle(PatientPhoneUpdatedEvent notification, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task Handle(PatientPhotoUpdatedEvent notification, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task Handle(PatientHeartRateUpdatedEvent notification, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}