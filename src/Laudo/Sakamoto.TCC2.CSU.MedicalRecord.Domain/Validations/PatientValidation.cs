using System;
using FluentValidation;
using Sakamoto.TCC2.CSU.MedicalRecord.Domain.Models;

namespace Sakamoto.TCC2.CSU.MedicalRecord.Domain.Validations
{
    public class PatientValidation : AbstractValidator<Patient>
    {
        public PatientValidation()
        {
            ValidateId();
            ValidateFullName();
        }

        private void ValidateFullName()
        {
            RuleFor(p => p.FullName)
                .NotEmpty().WithMessage("Please ensure you have entered the full name")
                .Length(2, 150).WithMessage("Patient name must have between 2 and 150 characters");
        }

        private void ValidateId()
        {
            RuleFor(p => p.Id)
                .NotEqual(Guid.Empty);
        }
    }
}