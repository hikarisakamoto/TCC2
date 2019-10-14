using System.Runtime.Serialization;
using MediatR;
using Sakamoto.TCC2.CSU.Domain.Core.Bus;
using Sakamoto.TCC2.CSU.Domain.Core.Commands;
using Sakamoto.TCC2.CSU.Domain.Core.Notifications;
using Sakamoto.TCC2.CSU.Patients.Domain.Interfaces;

namespace Sakamoto.TCC2.CSU.Patients.Domain.CommandHandlers
{
    public class CommandHandler
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMediatorHandler _bus;
        private readonly DomainNotificationHandler _domainNotifications;

        public CommandHandler(IUnitOfWork unitOfWork, IMediatorHandler bus, INotificationHandler<DomainNotification> domainNotifications)
        {
            _unitOfWork = unitOfWork;
            _bus = bus;
            _domainNotifications = (DomainNotificationHandler)domainNotifications;
        }

        protected void NotifyValidationErrors(Command message)
        {
            foreach (var error in message.ValidationResult.Errors)
            {
                _bus.RaiseEvent(new DomainNotification(message.MessageType, error.ErrorMessage));
            }
        }

        public bool Commit()
        {
            if (_domainNotifications.HasNotifications()) return false;
            if (_unitOfWork.Commit()) return true;

            _bus.RaiseEvent(new DomainNotification("Commit", "Error commiting your data, please verify."));
            return false;
        }
    }
}