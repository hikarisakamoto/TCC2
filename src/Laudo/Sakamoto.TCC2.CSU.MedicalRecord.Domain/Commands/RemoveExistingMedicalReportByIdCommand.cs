using System;
using Sakamoto.TCC2.CSU.MedicalRecord.Domain.Validations;

namespace Sakamoto.TCC2.CSU.MedicalRecord.Domain.Commands
{
    public class RemoveExistingMedicalReportByIdCommand : MedicalReportCommand
    {
        public RemoveExistingMedicalReportByIdCommand(Guid medicalReportId, Guid practitionerId, Guid patientId)
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
            ValidationResult = new RemoveExistingMedicalReportByIdCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}