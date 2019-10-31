﻿using System;
using FluentValidation;
using Sakamoto.TCC2.CSU.MedicalRecord.Domain.Commands;

namespace Sakamoto.TCC2.CSU.MedicalRecord.Domain.Validations
{
    public class
        RemoveExistingMedicalReportByIdCommandValidation : AbstractValidator<RemoveExistingMedicalReportByIdCommand>
    {
        public RemoveExistingMedicalReportByIdCommandValidation()
        {
            ValidateId();
            ValidatePatientId();
            ValidatePractitionerId();
        }

        private void ValidateId()
        {
            RuleFor(p => p.MedicalReportId)
                .NotEqual(Guid.Empty).WithMessage("Medical Report ID is empty");
        }

        private void ValidatePatientId()
        {
            RuleFor(p => p.PatientId)
                .NotEqual(Guid.Empty).WithMessage("Patient ID is empty");
            ;
        }

        private void ValidatePractitionerId()
        {
            RuleFor(p => p.PractitionerId)
                .NotEqual(Guid.Empty).WithMessage("Practitioner ID is empty");
            ;
        }
    }
}