using System;
using FluentValidation;
using Sakamoto.TCC2.CSU.Practitioners.Domain.Models;

namespace Sakamoto.TCC2.CSU.Practitioners.Domain.Validations
{
    public class PractitionerValidation : AbstractValidator<Practitioner>
    {
        public PractitionerValidation()
        {
            ValidateCrm();
            ValidateEmail();
            ValidateExpertise();
            ValidateFullName();
            ValidateId();
            ValidatePhone();
        }

        private void ValidateCrm()
        {
            RuleFor(p => p.CRM)
                .NotEmpty().NotNull().WithMessage("Please ensure you have entered a CRM.")
                .MaximumLength(30).WithMessage("CRM can't have more than 30 characters.");
        }

        private void ValidateEmail()
        {
            RuleFor(p => p.Email)
                .EmailAddress().WithMessage("Please insert a valid email.")
                .MaximumLength(100).WithMessage("Email can't have more than 100 characters.");
        }

        private void ValidateExpertise()
        {
            RuleFor(p => p.Expertise)
                .NotEmpty().NotNull().WithMessage("Please ensure you have filled a expertise.")
                .Length(3, 300).WithMessage("Expertise description must have between 3 and 300 characters.");
        }

        private void ValidateFullName()
        {
            RuleFor(p => p.FullName)
                .NotEmpty().WithMessage("Please ensure you have entered the full name.")
                .Length(2, 150).WithMessage("Practitioner name must have between 2 and 150 characters.");
        }

        private void ValidateId()
        {
            RuleFor(p => p.Id)
                .NotEqual(Guid.Empty).WithMessage("Invalid ID.");
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