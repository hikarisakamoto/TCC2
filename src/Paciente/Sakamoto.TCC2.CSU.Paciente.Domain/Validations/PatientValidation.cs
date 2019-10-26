using System;
using FluentValidation;
using Sakamoto.TCC2.CSU.Patients.Domain.Commands;

namespace Sakamoto.TCC2.CSU.Patients.Domain.Validations
{
    public abstract class PatientValidation<T> : AbstractValidator<T> where T : PatientCommand
    {
        protected void ValidateBirthDate()
        {
            RuleFor(p => p.BirthDate)
                .NotEmpty().WithMessage("Please fill patient's birthdate.")
                .LessThanOrEqualTo(DateTime.Now).WithMessage("Please add valid birthdate.");
        }

        protected void ValidateCpf()
        {
            RuleFor(p => p.Cpf)
                .Must(cpf => cpf.IsValid()).WithMessage("Please insert a valid CPF.");
        }

        protected void ValidateFullName()
        {
            RuleFor(p => p.FullName)
                .NotEmpty().WithMessage("Please ensure you have entered the full name")
                .Length(2, 150).WithMessage("Patient name must have between 2 and 150 characters");
        }

        protected void ValidateId()
        {
            RuleFor(p => p.Id)
                .NotEqual(Guid.Empty).WithMessage("Invalid ID.");
        }

        protected void ValidatePhone()
        {
            RuleFor(p => p.Phone)
                .NotEmpty().WithMessage("Please add a phone number.")
                .NotNull().WithMessage("Please add a phone number.");
        }
    }
}