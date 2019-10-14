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
        IRequestHandler<UpdatePatientCommand, bool>
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IMediatorHandler _bus;

        public PatientCommandHandler(IUnitOfWork unitOfWork, IMediatorHandler bus,
            INotificationHandler<DomainNotification> domainNotifications, IPatientRepository patientRepository) : base(unitOfWork, bus, domainNotifications)
        {
            _bus = bus;
            _patientRepository = patientRepository;
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
                .WithGender(message.Gender).WithPhone(message.Phone).Build();

            if (_patientRepository.GetByCpf(patient.Cpf.Value) != null)
            {
                _bus.RaiseEvent(new DomainNotification(message.MessageType,
                    $"There is already a patient registered with this CPF ({patient.Cpf.Value})"));
                return Task.FromResult(false);

            }

            _patientRepository.Add(patient);

            if (Commit())
            {
                _bus.RaiseEvent(new PatientRegisteredEvent(patient.Id, patient.FullName, patient.BirthDate,
                    patient.Cpf.Value, patient.Gender, patient.Phone));


            }

            return Task.FromResult(true);
        }

        public Task<bool> Handle(UpdatePatientCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}