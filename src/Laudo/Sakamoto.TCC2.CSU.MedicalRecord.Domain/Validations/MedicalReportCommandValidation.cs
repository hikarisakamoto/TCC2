using System;
using FluentValidation;
using Sakamoto.TCC2.CSU.MedicalRecord.Domain.Commands;

namespace Sakamoto.TCC2.CSU.MedicalRecord.Domain.Validations
{
    public class MedicalReportCommandValidation<T> : AbstractValidator<T> where T : MedicalReportCommand
    {
        protected void ValidateLongDescription()
        {
            RuleFor(mr => mr.LongDescription)
                .MinimumLength(30).WithMessage("Long description mas be at least 30 characters long.")
                .NotEmpty().NotNull().WithMessage("Long description must be at least 30 characters long.");
        }

        protected void ValidatePatientId()
        {
            RuleFor(mr => mr.Patient.Id)
                .NotEqual(Guid.Empty).WithMessage("Patient's ID is empty.");
        }

        protected void ValidatePatientName()
        {
            RuleFor(mr => mr.Patient.FullName)
                .NotEmpty().WithMessage("Please ensure you have entered patient's full name")
                .Length(2, 150).WithMessage("Patient name must have between 2 and 150 characters");
        }

        protected void ValidatePractitionerId()
        {
            RuleFor(mr => mr.Practitioner.Id)
                .NotEqual(Guid.Empty).WithMessage("Practitioner's ID is empty.");
        }

        protected void ValidatePractitionerName()
        {
            RuleFor(mr => mr.Practitioner.FullName)
                .NotEmpty().WithMessage("Please ensure you have entered practitioner's full name")
                .Length(2, 150).WithMessage("Practitioner name must have between 2 and 150 characters");
        }

        protected void ValidateShortDescription()
        {
            RuleFor(mr => mr.ShortDescription)
                .Length(30, 300).WithMessage("Short description must be between 30 and 300 characters.")
                .NotEmpty().NotNull().WithMessage("Short description must be at least 30 characters long.");
        }
    }
}