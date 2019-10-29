using FluentValidation;
using Sakamoto.TCC2.CSU.Practitioners.Domain.Commands;

namespace Sakamoto.TCC2.CSU.Practitioners.Domain.Validations
{
    public class
        UpdatePractitionerEmailCommandValidation : PractitionerCommandValidation<UpdatePractitionerEmailCommand>
    {
        public UpdatePractitionerEmailCommandValidation()
        {
            ValidateEmail();
            ValidateId();
        }

        private void ValidateEmail()
        {
            RuleFor(p => p.Email)
                .EmailAddress().WithMessage("Please insert a valid email.")
                .MaximumLength(100).WithMessage("Email can't have more than 100 characters.");
        }
    }
}