using Sakamoto.TCC2.CSU.MedicalRecord.Domain.Models;
using Sakamoto.TCC2.CSU.MedicalRecord.Domain.Validations;

namespace Sakamoto.TCC2.CSU.MedicalRecord.Domain.Commands
{
    public class AddNewMedicalRecordCommand : MedicalReportCommand
    {
        public AddNewMedicalRecordCommand(string longDescription, Patient patient, Practitioner practitioner,
            string shortDescription)
        {
            LongDescription = longDescription;
            Patient = patient;
            Practitioner = practitioner;
            ShortDescription = shortDescription;
        }

        public override bool IsValid()
        {
            ValidationResult = new AddNewMedicalRecordCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}