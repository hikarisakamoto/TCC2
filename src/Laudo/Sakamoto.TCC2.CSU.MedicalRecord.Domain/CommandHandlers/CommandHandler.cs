using System.Threading.Tasks;
using FluentValidation.Results;
using MediatR;
using Sakamoto.TCC2.CSU.Domain.Core.Bus;
using Sakamoto.TCC2.CSU.Domain.Core.Commands;
using Sakamoto.TCC2.CSU.Domain.Core.Notifications;
using Sakamoto.TCC2.CSU.MedicalRecord.Domain.Interfaces;

namespace Sakamoto.TCC2.CSU.MedicalRecord.Domain.CommandHandlers
{
    public abstract class CommandHandler
    {
        private readonly IMediatorHandler _bus;
        private readonly DomainNotificationHandler _domainNotifications;
        private readonly IMedicalRecordRepository _medicalRecordRepository;


        protected CommandHandler(IMedicalRecordRepository medicalRecordRepository, IMediatorHandler bus,
            INotificationHandler<DomainNotification> domainNotifications)
        {
            _medicalRecordRepository = medicalRecordRepository;
            _bus = bus;
            _domainNotifications = (DomainNotificationHandler) domainNotifications;
        }

        protected async Task<bool> Commit()
        {
            return !_domainNotifications.HasNotifications();
        }

        protected void NotifyValidationErrors(Command message)
        {
            foreach (var error in message.ValidationResult.Errors)
                _bus.RaiseEvent(new DomainNotification(message.MessageType, error.ErrorMessage));
        }

        protected void NotifyValidationErrors(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
                _bus.RaiseEvent(new DomainNotification(error.PropertyName, error.ErrorMessage));
        }
    }
}