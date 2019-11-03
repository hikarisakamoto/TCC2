using System;
using Sakamoto.TCC2.CSU.MedicalRecord.Domain.Validations;

namespace Sakamoto.TCC2.CSU.MedicalRecord.Domain.Commands
{
    public class RemoveExistingMedicalRecordtByIdCommand : MedicalReportCommand
    {
        public RemoveExistingMedicalRecordtByIdCommand(Guid medicalReportId, Guid practitionerId, Guid patientId)
        {
            MedicalReportId = medicalReportId;
            PractitionerId = practitionerId;
            PatientId = patientId;
        }

        public Guid MedicalReportId { get; }
        public Guid PatientId { get; }
        public Guid PractitionerId { get; }

        public override bool IsValid()
        {
            ValidationResult = new RemoveExistingMedicalRecordByIdCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}