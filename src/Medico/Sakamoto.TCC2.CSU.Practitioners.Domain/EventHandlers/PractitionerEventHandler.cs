using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Sakamoto.TCC2.CSU.Practitioners.Domain.Events;

namespace Sakamoto.TCC2.CSU.Practitioners.Domain.EventHandlers
{
    public class PractitionerEventHandler :
        INotificationHandler<PractitionerRegisteredEvent>,
        INotificationHandler<PractitionerDeactivatedEvent>,
        INotificationHandler<PractitionerPhoneUpdatedEvent>,
        INotificationHandler<PractitionerEmailUpdatedEvent>
    {
        public Task Handle(PractitionerDeactivatedEvent notification, CancellationToken cancellationToken)
        {
            // TODO SEND PRACTITIONER DEACTIVATED MESSAGE

            return Task.CompletedTask;
        }

        public Task Handle(PractitionerEmailUpdatedEvent notification, CancellationToken cancellationToken)
        {
            // TODO SEND PRACTITIONER EMAIL UPDATED MESSAGE

            return Task.CompletedTask;
        }

        public Task Handle(PractitionerPhoneUpdatedEvent notification, CancellationToken cancellationToken)
        {
            // TODO SEND PRACTITIONER PHONE UPDATED MESSAGE

            return Task.CompletedTask;
        }

        public Task Handle(PractitionerRegisteredEvent notification, CancellationToken cancellationToken)
        {
            // TODO SEND PRACTITIONER REGISTERED MESSAGE

            return Task.CompletedTask;
        }
    }
}