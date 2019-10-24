using FluentValidation;
using Sakamoto.TCC2.CSU.Practitioners.Domain.PractitionerCommands;

namespace Sakamoto.TCC2.CSU.Practitioners.Domain.Validations
{
    public class
        UpdatePractitionerPhoneCommandValidation : PractitionerCommandValidation<UpdatePractitionerPhoneCommand>
    {
        public UpdatePractitionerPhoneCommandValidation()
        {
            ValidatePhone();
            ValidateId();
        }

        private void ValidatePhone()
        {
            RuleFor(p => p.Phone)
                .MaximumLength(20).WithMessage("Phone number can't have more than 20 characters.")
                .NotEmpty().WithMessage("Please add a phone number.")
                .NotNull().WithMessage("Please add a phone number.");
        }
    }
}