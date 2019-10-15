using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Sakamoto.TCC2.CSU.Domain.Core.Bus;
using Sakamoto.TCC2.CSU.Domain.Core.Notifications;
using Sakamoto.TCC2.CSU.Patients.Domain.Commands;
using Sakamoto.TCC2.CSU.Patients.Domain.Events;
using Sakamoto.TCC2.CSU.Patients.Domain.Interfaces;
using Sakamoto.TCC2.CSU.Patients.Domain.Models;

namespace Sakamoto.TCC2.CSU.Patients.Domain.CommandHandlers
{
    public class PatientCommandHandler : CommandHandler, IRequestHandler<RegisterNewPatientCommand, bool>,
        IRequestHandler<UpdatePatientCommand, bool>, IRequestHandler<DeactivatePatientCommand, bool>
    {
        private readonly IMediatorHandler _bus;
        private readonly IPatientRepository _patientRepository;

        public PatientCommandHandler(IUnitOfWork unitOfWork, IMediatorHandler bus,
            INotificationHandler<DomainNotification> domainNotifications, IPatientRepository patientRepository) : base(
            unitOfWork, bus, domainNotifications)
        {
            _bus = bus;
            _patientRepository = patientRepository;
        }

        public Task<bool> Handle(DeactivatePatientCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }

            var existingPatient = _patientRepository.GetByCpf(message.Cpf.Value);

            if (existingPatient == null)
            {
                _bus.RaiseEvent(new DomainNotification(message.MessageType, "Patient not found."));
                return Task.FromResult(false);
            }

            if (existingPatient.Id != message.Id)
            {
                _bus.RaiseEvent(new DomainNotification(message.MessageType,
                    "Patient identification does not match, please verify."));
                return Task.FromResult(false);
            }

            var patient = new Patient.Builder(existingPatient.Id).BornIn(existingPatient.BirthDate)
                .Named(existingPatient.FullName).ThatLivesIn(existingPatient.Address).WithCpf(existingPatient.Cpf)
                .WithEmail(existingPatient.Email).WithGender(existingPatient.Gender).WithPhone(message.Phone)
                .WithPhoto(existingPatient.Photo).WhichIsInactive().Build();

            _patientRepository.Update(patient);

            if (Commit())
                _bus.RaiseEvent(new PatientDeactivatedEvent(patient.Id, patient.FullName, patient.BirthDate,
                    patient.Cpf.Value, patient.Gender, patient.Email, patient.Phone, patient.Photo, patient.Address,
                    patient.IsActive));

            return Task.FromResult(true);
        }

        public Task<bool> Handle(RegisterNewPatientCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }

            var patient = new Patient.Builder(Guid.NewGuid()).Named(message.FullName).BornIn(message.BirthDate)
                .WithCpf(message.Cpf)
                .WithGender(message.Gender).WithPhone(message.Phone).WhichIsActive().Build();

            if (_patientRepository.GetByCpf(patient.Cpf.Value) != null)
            {
                _bus.RaiseEvent(new DomainNotification(message.MessageType,
                    $"There is already a patient registered with this CPF ({patient.Cpf.Value})"));
                return Task.FromResult(false);
            }

            _patientRepository.Add(patient);

            if (Commit())
                _bus.RaiseEvent(new PatientRegisteredEvent(patient.Id, patient.FullName, patient.BirthDate,
                    patient.Cpf.Value, patient.Gender, patient.Phone));

            return Task.FromResult(true);
        }

        public Task<bool> Handle(UpdatePatientCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }

            var existingPatient = _patientRepository.GetByCpf(message.Cpf.Value);

            if (existingPatient == null)
            {
                _bus.RaiseEvent(new DomainNotification(message.MessageType, "Patient not found."));
                return Task.FromResult(false);
            }

            if (existingPatient.Id != message.Id)
            {
                _bus.RaiseEvent(new DomainNotification(message.MessageType,
                    "Patient identification does not match, please verify."));
                return Task.FromResult(false);
            }

            var patient = new Patient.Builder(existingPatient.Id).BornIn(existingPatient.BirthDate)
                .Named(existingPatient.FullName).ThatLivesIn(message.Address).WithCpf(existingPatient.Cpf)
                .WithEmail(message.Email).WithGender(existingPatient.Gender).WithPhone(message.Phone)
                .WithPhoto(message.Photo).WhichIsActive().Build();

            _patientRepository.Update(patient);

            if (Commit())
                _bus.RaiseEvent(new PatientUpdatedEvent(patient.Id, patient.FullName, patient.BirthDate,
                    patient.Cpf.Value, patient.Gender, patient.Email, patient.Phone, patient.Photo, patient.Address,
                    patient.IsActive));

            return Task.FromResult(true);
        }
    }
}