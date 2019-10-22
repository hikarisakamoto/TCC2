using System;
using FluentValidation;
using Sakamoto.TCC2.CSU.Patients.Domain.Models;

namespace Sakamoto.TCC2.CSU.Patients.Domain.Validations
{
    public class PatientDomainValidation : AbstractValidator<Patient>
    {
        public PatientDomainValidation()
        {
            ValidateBirthDate();
            ValidateCpf();
            ValidateEmail();
            ValidateCpfLength();
            ValidateId();
            ValidatePhone();
            ValidateFullName();
        }

        private void ValidateFullName()
        {
            RuleFor(p => p.FullName)
                .NotEmpty().WithMessage("Please ensure you have entered the full name")
                .Length(2, 150).WithMessage("Patient name must have between 2 and 150 characters");
        }

        private void ValidateBirthDate()
        {
            RuleFor(p => p.BirthDate)
                .NotEmpty().WithMessage("Please fill patient's birthdate.")
                .LessThanOrEqualTo(DateTime.Now).WithMessage("Please add valid birthdate.");
        }

        private void ValidateEmail()
        {
            RuleFor(p => p.Email)
                .EmailAddress().WithMessage("Please insert a valid email.")
                .MaximumLength(100).WithMessage("Email must can't have more than 100 characters.");
        }

        private void ValidateCpfLength()
        {
            RuleFor(p => p.Cpf.Value)
                .Length(11).WithMessage("CPF must be 11 characters long.");
        }

        private void ValidateCpf()
        {
            RuleFor(p => p.Cpf)
                .Must(cpf => cpf.IsValid()).WithMessage("Please insert a valid CPF.");
        }

        private void ValidateId()
        {
            RuleFor(p => p.Id)
                .NotEqual(Guid.Empty);
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