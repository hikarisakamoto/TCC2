using Sakamoto.TCC2.CSU.MedicalRecord.Domain.Models;
using Sakamoto.TCC2.CSU.MedicalRecord.Domain.Validations;

namespace Sakamoto.TCC2.CSU.MedicalRecord.Domain.Commands
{
    public class AddNewMedicalReportCommand : MedicalReportCommand
    {
        public AddNewMedicalReportCommand(string longDescription, Patient patient, Practitioner practitioner,
            string shortDescription)
        {
            LongDescription = longDescription;
            Patient = patient;
            Practitioner = practitioner;
            ShortDescription = shortDescription;
        }

        public override bool IsValid()
        {
            ValidationResult = new AddNewMedicalReportCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}