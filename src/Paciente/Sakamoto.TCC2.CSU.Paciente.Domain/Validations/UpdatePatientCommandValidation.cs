using FluentValidation;
using Sakamoto.TCC2.CSU.Patients.Domain.Commands;

namespace Sakamoto.TCC2.CSU.Patients.Domain.Validations
{
    public class UpdatePatientCommandValidation : PatientValidation<UpdatePatientCommand>
    {
        public UpdatePatientCommandValidation()
        {
            ValidateId();
            ValidateEmail();
            ValidateAddress();
            ValidatePhoto();
        }

        private void ValidateAddress()
        {
            RuleFor(p => p.Address).Must(a => a.IsValid()).WithMessage("Address has invalid information.");
        }

        private void ValidateEmail()
        {
            RuleFor(p => p.Email)
                .NotEmpty().NotNull().WithMessage("Please fill in an email.")
                .EmailAddress().WithMessage("Please add a valid email address.");
        }

        private void ValidatePhoto()
        {
            RuleFor(p => p.Photo)
                .NotNull().NotEmpty().WithMessage("Please add a picture of the patient for further recognition.");
        }
    }
}