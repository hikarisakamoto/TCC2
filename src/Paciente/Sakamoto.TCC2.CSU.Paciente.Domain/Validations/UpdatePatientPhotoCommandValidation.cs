using FluentValidation;
using Sakamoto.TCC2.CSU.Patients.Domain.Commands;

namespace Sakamoto.TCC2.CSU.Patients.Domain.Validations
{
    public class UpdatePatientPhotoCommandValidation : PatientCommandValidation<UpdatePatientPhotoCommand>
    {
        public UpdatePatientPhotoCommandValidation()
        {
            ValidateId();
            ValidatePhoto();
        }

        private void ValidatePhoto()
        {
            RuleFor(p => p.Photo)
                .NotNull().NotEmpty().WithMessage("Please add a picture of the patient for further recognition.");
        }
    }
}