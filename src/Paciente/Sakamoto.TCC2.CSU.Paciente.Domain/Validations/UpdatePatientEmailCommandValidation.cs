using FluentValidation;
using Sakamoto.TCC2.CSU.Patients.Domain.Commands;

namespace Sakamoto.TCC2.CSU.Patients.Domain.Validations
{
    public class UpdatePatientEmailCommandValidation : PatientValidation<UpdatePatientEmailCommand>
    {
        public UpdatePatientEmailCommandValidation()
        {
            ValidateId();
            ValidateEmail();
        }

        private void ValidateEmail()
        {
            RuleFor(p => p.Email)
                .NotEmpty().NotNull().WithMessage("Please fill in an email.")
                .EmailAddress().WithMessage("Please add a valid email address.");
        }
    }
}