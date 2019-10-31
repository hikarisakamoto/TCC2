using Sakamoto.TCC2.CSU.MedicalRecord.Domain.Models;
using Sakamoto.TCC2.CSU.MedicalRecord.Domain.Validations;

namespace Sakamoto.TCC2.CSU.MedicalRecord.Domain.Commands
{
    public class AddNewMedicalReportWithImageCommand : MedicalReportCommand
    {
        public AddNewMedicalReportWithImageCommand(string longDescription, Patient patient, Practitioner practitioner,
            string shortDescription, byte[] image)
        {
            LongDescription = longDescription;
            Patient = patient;
            Practitioner = practitioner;
            ShortDescription = shortDescription;
            Image = image;
        }

        public byte[] Image { get; }

        public override bool IsValid()
        {
            ValidationResult = new AddNewMedicalReportWithImageCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}