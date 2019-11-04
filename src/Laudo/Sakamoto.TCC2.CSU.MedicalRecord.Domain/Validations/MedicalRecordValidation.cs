using System;
using FluentValidation;

namespace Sakamoto.TCC2.CSU.MedicalRecord.Domain.Validations
{
    public class MedicalRecordValidation : AbstractValidator<Models.MedicalRecord>
    {
        public MedicalRecordValidation()
        {
            ValidateDate();
            ValidateId();
            ValidateLongDescription();
            ValidatePatientId();
            ValidatePatientName();
            ValidatePractitionerId();
            ValidatePractitionerName();
            ValidateShortDescription();
        }

        private void ValidateDate()
        {
            RuleFor(mr => mr.Date)
                .LessThanOrEqualTo(DateTime.Now).WithMessage("Can't have a future date.");
        }

        private void ValidateId()
        {
            RuleFor(mr => mr.Id)
                .NotEqual(Guid.Empty);
        }

        private void ValidateLongDescription()
        {
            RuleFor(mr => mr.LongDescription)
                .MinimumLength(30).WithMessage("Long description mas be at least 30 characters long.")
                .NotEmpty().NotNull().WithMessage("Long description must be at least 30 characters long.");
        }

        private void ValidatePatientId()
        {
            RuleFor(mr => mr.PatientId)
                .NotEqual(Guid.Empty).WithMessage("Patient's ID is empty.");
        }

        private void ValidatePatientName()
        {
            RuleFor(mr => mr.PatientName)
                .NotEmpty().WithMessage("Please ensure you have entered patient's full name")
                .Length(2, 150).WithMessage("Patient name must have between 2 and 150 characters");
        }

        private void ValidatePractitionerId()
        {
            RuleFor(mr => mr.PractitionerId)
                .NotEqual(Guid.Empty).WithMessage("Practitioner's ID is empty.");
        }

        private void ValidatePractitionerName()
        {
            RuleFor(mr => mr.PractitionerName)
                .NotEmpty().WithMessage("Please ensure you have entered practitioner's full name")
                .Length(2, 150).WithMessage("Practitioner name must have between 2 and 150 characters");
        }

        private void ValidateShortDescription()
        {
            RuleFor(mr => mr.ShortDescription)
                .Length(30, 300).WithMessage("Short description must be between 30 and 300 characters.")
                .NotEmpty().NotNull().WithMessage("Short description must be at least 30 characters long.");
        }
    }
}