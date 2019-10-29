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
using Sakamoto.TCC2.CSU.Patients.Domain.ValueObjects;

namespace Sakamoto.TCC2.CSU.Patients.Domain.CommandHandlers
{
    public class PatientCommandHandler : CommandHandler
        , IRequestHandler<RegisterNewPatientCommand, bool>
        , IRequestHandler<DeactivatePatientCommand, bool>
        , IRequestHandler<UpdatePatientAddressCommand, bool>
        , IRequestHandler<UpdatePatientEmailCommand, bool>
        , IRequestHandler<UpdatePatientPhoneCommand, bool>
        , IRequestHandler<UpdatePatientPhotoCommand, bool>
        , IRequestHandler<UpdatePatientHeartRateCommand, bool>
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

            var existingPatient = _patientRepository.GetByCpf(message.Cpf);

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
                .WithPhoto(existingPatient.Photo).WhichIsInactive().WithHeartRate(existingPatient.HeartRate).Build();

            if (!patient.IsValid())
            {
                NotifyValidationErrors(patient.ValidationResult);
                return Task.FromResult(false);
            }

            _patientRepository.Update(patient);

            if (Commit())
                _bus.RaiseEvent(new PatientDeactivatedEvent(patient));

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

            if (_patientRepository.GetByCpf(patient.Cpf) != null)
            {
                _bus.RaiseEvent(new DomainNotification(message.MessageType,
                    $"There is already a patient registered with this CPF ({patient.Cpf})"));
                return Task.FromResult(false);
            }

            if (!patient.IsValid())
            {
                NotifyValidationErrors(patient.ValidationResult);
                return Task.FromResult(false);
            }

            _patientRepository.Add(patient);

            if (Commit())
                _bus.RaiseEvent(new PatientRegisteredEvent(patient));

            return Task.FromResult(true);
        }

        public Task<bool> Handle(UpdatePatientAddressCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }

            var existingPatient = _patientRepository.GetById(message.Id);

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

            var address = new Address.Builder().InCityOf(message.City).InTheDistrict(message.District)
                .InTheState(message.State).WithNumber(message.Number).WithObservation(message.Observation)
                .WithPostalCode(message.PostalCode).WithStreet(message.Street).Build();

            var patient = new Patient.Builder(existingPatient.Id).BornIn(existingPatient.BirthDate)
                .Named(existingPatient.FullName).ThatLivesIn(address).WithCpf(existingPatient.Cpf)
                .WithEmail(existingPatient.Email).WithGender(existingPatient.Gender).WithPhone(existingPatient.Phone)
                .WithPhoto(existingPatient.Photo).WhichIsActive().WithHeartRate(existingPatient.HeartRate).Build();

            if (!patient.IsValid())
            {
                NotifyValidationErrors(patient.ValidationResult);
                return Task.FromResult(false);
            }

            _patientRepository.Update(patient);

            if (Commit())
                _bus.RaiseEvent(new PatientAddressUpdatedEvent(patient));

            return Task.FromResult(true);
        }

        public Task<bool> Handle(UpdatePatientEmailCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }

            var existingPatient = _patientRepository.GetById(message.Id);

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
                .WithEmail(message.Email).WithGender(existingPatient.Gender).WithPhone(existingPatient.Phone)
                .WithPhoto(existingPatient.Photo).WhichIsActive().WithHeartRate(existingPatient.HeartRate).Build();

            if (!patient.IsValid())
            {
                NotifyValidationErrors(patient.ValidationResult);
                return Task.FromResult(false);
            }

            _patientRepository.Update(patient);

            if (Commit())
                _bus.RaiseEvent(new PatientEmailUpdatedEvent(patient));

            return Task.FromResult(true);
        }

        public Task<bool> Handle(UpdatePatientHeartRateCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }

            var existingPatient = _patientRepository.GetById(message.Id);

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
                .WithEmail(existingPatient.Email).WithGender(existingPatient.Gender).WithPhone(existingPatient.Phone)
                .WithPhoto(existingPatient.Photo).WhichIsActive().WithHeartRate(message.HeartRate).Build();

            if (!patient.IsValid())
            {
                NotifyValidationErrors(patient.ValidationResult);
                return Task.FromResult(false);
            }

            _patientRepository.Update(patient);

            if (Commit())
                _bus.RaiseEvent(new PatientHeartRateUpdatedEvent(patient));

            return Task.FromResult(true);
        }

        public Task<bool> Handle(UpdatePatientPhoneCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }

            var existingPatient = _patientRepository.GetById(message.Id);

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
                .WithPhoto(existingPatient.Photo).WhichIsActive().WithHeartRate(existingPatient.HeartRate).Build();

            if (!patient.IsValid())
            {
                NotifyValidationErrors(patient.ValidationResult);
                return Task.FromResult(false);
            }

            _patientRepository.Update(patient);

            if (Commit())
                _bus.RaiseEvent(new PatientPhoneUpdatedEvent(patient));

            return Task.FromResult(true);
        }

        public Task<bool> Handle(UpdatePatientPhotoCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }

            var existingPatient = _patientRepository.GetById(message.Id);

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
                .WithEmail(existingPatient.Email).WithGender(existingPatient.Gender).WithPhone(existingPatient.Phone)
                .WithPhoto(message.Photo).WhichIsActive().WithHeartRate(existingPatient.HeartRate).Build();

            if (!patient.IsValid())
            {
                NotifyValidationErrors(patient.ValidationResult);
                return Task.FromResult(false);
            }

            _patientRepository.Update(patient);

            if (Commit())
                _bus.RaiseEvent(new PatientPhoneUpdatedEvent(patient));

            return Task.FromResult(true);
        }
    }
}