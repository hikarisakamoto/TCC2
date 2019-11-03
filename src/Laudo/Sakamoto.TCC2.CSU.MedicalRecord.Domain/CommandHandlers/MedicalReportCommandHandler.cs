using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Sakamoto.TCC2.CSU.Domain.Core.Bus;
using Sakamoto.TCC2.CSU.Domain.Core.Notifications;
using Sakamoto.TCC2.CSU.MedicalRecord.Domain.Commands;
using Sakamoto.TCC2.CSU.MedicalRecord.Domain.Events;
using Sakamoto.TCC2.CSU.MedicalRecord.Domain.Interfaces;

namespace Sakamoto.TCC2.CSU.MedicalRecord.Domain.CommandHandlers
{
    public class MedicalReportCommandHandler : CommandHandler,
        IRequestHandler<AddNewMedicalRecordCommand, bool>,
        IRequestHandler<AddNewMedicalReportWithImageCommand, bool>,
        IRequestHandler<RemoveExistingMedicalRecordtByIdCommand, bool>

    {
        private readonly IMediatorHandler _bus;
        private readonly IMedicalRecordRepository _medicalRecordRepository;

        public MedicalReportCommandHandler(IMedicalRecordRepository medicalRecordRepository, IMediatorHandler bus,
            INotificationHandler<DomainNotification> domainNotifications) : base(medicalRecordRepository, bus, domainNotifications)
        {
            _bus = bus;
            _medicalRecordRepository = medicalRecordRepository;
        }

        public async Task<bool> Handle(AddNewMedicalRecordCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return await Task.FromResult(false);
            }

            var medicalReport = new Models.MedicalRecord.Builder()
                .WithPatient(message.Patient)
                .WithPractitioner(message.Practitioner)
                .WithShortDescription(message.ShortDescription)
                .WithLongDescription(message.LongDescription)
                .Build();


            if (!medicalReport.IsValid())
            {
                NotifyValidationErrors(medicalReport.ValidationResult);
                return await Task.FromResult(false);
            }

            _medicalRecordRepository.Add(medicalReport);

            if (await Commit())
                await _bus.RaiseEvent(new MedicalReportAddedEvent(medicalReport));

            return await Task.FromResult(true);
        }

        public async Task<bool> Handle(AddNewMedicalReportWithImageCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return await Task.FromResult(false);
            }

            var medicalReport = new Models.MedicalRecord.Builder()
                .WithPatient(message.Patient)
                .WithPractitioner(message.Practitioner)
                .WithShortDescription(message.ShortDescription)
                .WithLongDescription(message.LongDescription)
                .WithImage(message.Image)
                .Build();


            if (!medicalReport.IsValid())
            {
                NotifyValidationErrors(medicalReport.ValidationResult);
                return await Task.FromResult(false);
            }

            _medicalRecordRepository.Add(medicalReport);

            if (await Commit())
                await _bus.RaiseEvent(new MedicalReportWithImageAddedEvent(medicalReport));

            return await Task.FromResult(true);
        }

        public async Task<bool> Handle(RemoveExistingMedicalRecordtByIdCommand message,
            CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return await Task.FromResult(false);
            }

            var medicalReport = _medicalRecordRepository.GetByRemovalParamaters(message.MedicalReportId,
                message.PatientId, message.PractitionerId);

            if (medicalReport == null)
            {
                await _bus.RaiseEvent(new DomainNotification(message.MessageType,
                    "No report return from the query, please verify."));
                return await Task.FromResult(false);
            }


            _medicalRecordRepository.Remove(medicalReport.Id);

            if (await Commit())
                await _bus.RaiseEvent(new MedicalReportRemovedEvent(message.MedicalReportId, message.PatientId,
                    message.PractitionerId));

            return await Task.FromResult(true);
        }
    }
}