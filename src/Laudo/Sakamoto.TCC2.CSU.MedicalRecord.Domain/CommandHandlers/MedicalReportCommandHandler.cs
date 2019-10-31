using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Sakamoto.TCC2.CSU.Domain.Core.Bus;
using Sakamoto.TCC2.CSU.Domain.Core.Notifications;
using Sakamoto.TCC2.CSU.MedicalRecord.Domain.Commands;
using Sakamoto.TCC2.CSU.MedicalRecord.Domain.Events;
using Sakamoto.TCC2.CSU.MedicalRecord.Domain.Interfaces;
using Sakamoto.TCC2.CSU.MedicalRecord.Domain.Models;

namespace Sakamoto.TCC2.CSU.MedicalRecord.Domain.CommandHandlers
{
    public class MedicalReportCommandHandler : CommandHandler,
        IRequestHandler<AddNewMedicalReportCommand, bool>,
        IRequestHandler<AddNewMedicalReportWithImageCommand, bool>,
        IRequestHandler<RemoveExistingMedicalReportByIdCommand, bool>

    {
        private readonly IMediatorHandler _bus;
        private readonly IMedicalReportRepository _medicalReportRepository;

        public MedicalReportCommandHandler(IUnitOfWork unitOfWork, IMediatorHandler bus,
            INotificationHandler<DomainNotification> domainNotifications,
            IMedicalReportRepository medicalReportRepository) : base(unitOfWork, bus, domainNotifications)
        {
            _bus = bus;
            _medicalReportRepository = medicalReportRepository;
        }

        public Task<bool> Handle(AddNewMedicalReportCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }

            var medicalReport = new MedicalReport.Builder()
                .WithPatient(message.Patient)
                .WithPractitioner(message.Practitioner)
                .WithShortDescription(message.ShortDescription)
                .WithLongDescription(message.LongDescription)
                .Build();


            if (!medicalReport.IsValid())
            {
                NotifyValidationErrors(medicalReport.ValidationResult);
                return Task.FromResult(false);
            }

            _medicalReportRepository.Add(medicalReport);

            if (Commit())
                _bus.RaiseEvent(new MedicalReportAddedEvent(medicalReport));

            return Task.FromResult(true);
        }

        public Task<bool> Handle(AddNewMedicalReportWithImageCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }

            var medicalReport = new MedicalReport.Builder()
                .WithPatient(message.Patient)
                .WithPractitioner(message.Practitioner)
                .WithShortDescription(message.ShortDescription)
                .WithLongDescription(message.LongDescription)
                .WithImage(message.Image)
                .Build();


            if (!medicalReport.IsValid())
            {
                NotifyValidationErrors(medicalReport.ValidationResult);
                return Task.FromResult(false);
            }

            _medicalReportRepository.Add(medicalReport);

            if (Commit())
                _bus.RaiseEvent(new MedicalReportWithImageAddedEvent(medicalReport));

            return Task.FromResult(true);
        }

        public async Task<bool> Handle(RemoveExistingMedicalReportByIdCommand message,
            CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return await Task.FromResult(false);
            }

            var medicalReport = await _medicalReportRepository.GetByRemovalParamaters(message.MedicalReportId,
                message.PatientId, message.PractitionerId);

            if (medicalReport == null)
            {
                _bus.RaiseEvent(new DomainNotification(message.MessageType,
                    "No report return from the query, please verify."));
                return await Task.FromResult(false);
            }


            _medicalReportRepository.Remove(medicalReport.Id);

            if (Commit())
                _bus.RaiseEvent(new MedicalReportRemovedEvent(message.MedicalReportId, message.PatientId,
                    message.PractitionerId));

            return await Task.FromResult(true);
        }
    }
}