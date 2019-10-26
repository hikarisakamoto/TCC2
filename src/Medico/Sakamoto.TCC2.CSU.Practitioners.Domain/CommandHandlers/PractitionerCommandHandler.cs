using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Sakamoto.TCC2.CSU.Domain.Core.Bus;
using Sakamoto.TCC2.CSU.Domain.Core.Notifications;
using Sakamoto.TCC2.CSU.Practitioners.Domain.Events;
using Sakamoto.TCC2.CSU.Practitioners.Domain.Interfaces;
using Sakamoto.TCC2.CSU.Practitioners.Domain.Models;
using Sakamoto.TCC2.CSU.Practitioners.Domain.PractitionerCommands;

namespace Sakamoto.TCC2.CSU.Practitioners.Domain.CommandHandlers
{
    public class PractitionerCommandHandler : CommandHandler,
        IRequestHandler<RegisterNewPractitionerCommand, bool>,
        IRequestHandler<UpdatePractitionerEmailCommand, bool>,
        IRequestHandler<UpdatePractitionerPhoneCommand, bool>,
        IRequestHandler<DeactivatePractitionerCommand, bool>
    {
        private readonly IMediatorHandler _bus;
        private readonly IPractitionerRepository _practitionerRepository;

        public PractitionerCommandHandler(IUnitOfWork unitOfWork, IMediatorHandler bus,
            INotificationHandler<DomainNotification> domainNotifications,
            IPractitionerRepository practitionerRepository) : base(unitOfWork, bus, domainNotifications)
        {
            _bus = bus;
            _practitionerRepository = practitionerRepository;
        }

        public Task<bool> Handle(DeactivatePractitionerCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }

            var existingPractitioner = _practitionerRepository.GetById(message.Id);

            if (existingPractitioner == null)
            {
                _bus.RaiseEvent(new DomainNotification(message.MessageType, "Practitioner not found."));
                return Task.FromResult(false);
            }

            var practitioner = new Practitioner.Builder(existingPractitioner.Id).Named(existingPractitioner.FullName)
                .WithCrm(existingPractitioner.CRM)
                .WithExpertiseIn(existingPractitioner.Expertise).WithPhone(existingPractitioner.Phone)
                .WithEmail(existingPractitioner.Email).WhichIsInactive().Build();

            if (!practitioner.IsValid())
            {
                NotifyValidationErrors(practitioner.ValidationResult);
                return Task.FromResult(false);
            }

            _practitionerRepository.Update(practitioner);

            if (Commit()) _bus.RaiseEvent(new PractitionerDeactivatedEvent(practitioner));
            return Task.FromResult(true);
        }

        public Task<bool> Handle(RegisterNewPractitionerCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }

            var practitioner = new Practitioner.Builder(Guid.NewGuid()).Named(message.FullName).WithCrm(message.CRM)
                .WithExpertiseIn(message.Expertise).WithPhone(message.Phone).WithEmail(message.Email).WhichIsActive()
                .Build();

            if (_practitionerRepository.GetByCrm(practitioner.CRM) != null)
            {
                _bus.RaiseEvent(new DomainNotification(message.MessageType,
                    $"There is already a practitioner registered with this CRM ({practitioner.CRM})"));
                return Task.FromResult(false);
            }

            _practitionerRepository.Add(practitioner);

            if (Commit())
                _bus.RaiseEvent(new PractitionerRegisteredEvent(practitioner));

            return Task.FromResult(true);
        }

        public Task<bool> Handle(UpdatePractitionerEmailCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }

            var existingPractitioner = _practitionerRepository.GetById(message.Id);

            if (existingPractitioner == null)
            {
                _bus.RaiseEvent(new DomainNotification(message.MessageType, "Practitioner not found."));
                return Task.FromResult(false);
            }

            var practitioner = new Practitioner.Builder(existingPractitioner.Id).Named(existingPractitioner.FullName)
                .WithCrm(existingPractitioner.CRM)
                .WithExpertiseIn(existingPractitioner.Expertise).WithPhone(existingPractitioner.Phone)
                .WithEmail(message.Email).WhichIsActive().Build();

            if (!practitioner.IsValid())
            {
                NotifyValidationErrors(practitioner.ValidationResult);
                return Task.FromResult(false);
            }

            _practitionerRepository.Update(practitioner);

            if (Commit()) _bus.RaiseEvent(new PractitionerEmailUpdatedEvent(practitioner));
            return Task.FromResult(true);
        }

        public Task<bool> Handle(UpdatePractitionerPhoneCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }

            var existingPractitioner = _practitionerRepository.GetById(message.Id);

            if (existingPractitioner == null)
            {
                _bus.RaiseEvent(new DomainNotification(message.MessageType, "Practitioner not found."));
                return Task.FromResult(false);
            }

            var practitioner = new Practitioner.Builder(existingPractitioner.Id).Named(existingPractitioner.FullName)
                .WithCrm(existingPractitioner.CRM)
                .WithExpertiseIn(existingPractitioner.Expertise).WithPhone(message.Phone)
                .WithEmail(existingPractitioner.Email).WhichIsActive().Build();

            if (!practitioner.IsValid())
            {
                NotifyValidationErrors(practitioner.ValidationResult);
                return Task.FromResult(false);
            }

            _practitionerRepository.Update(practitioner);

            if (Commit()) _bus.RaiseEvent(new PractitionerPhoneUpdatedEvent(practitioner));
            return Task.FromResult(true);
        }
    }
}