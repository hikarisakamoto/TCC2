using FluentValidation;
using Sakamoto.TCC2.CSU.MedicalRecord.Domain.Commands;

namespace Sakamoto.TCC2.CSU.MedicalRecord.Domain.Validations
{
    public class
        AddNewMedicalRecordWithImageCommandValidation : MedicalRecordCommandValidation<
            AddNewMedicalReportWithImageCommand>
    {
        public AddNewMedicalRecordWithImageCommandValidation()
        {
            ValidateImage();
            ValidateLongDescription();
            ValidatePatientId();
            ValidatePatientName();
            ValidatePractitionerId();
            ValidatePractitionerName();
            ValidateShortDescription();
        }

        private void ValidateImage()
        {
            RuleFor(mr => mr.Image)
                .NotNull().NotEmpty().WithMessage("Image provided was not loaded or is corrupted.");
        }
    }
}