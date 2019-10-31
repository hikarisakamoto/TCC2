using System;
using Sakamoto.TCC2.CSU.Domain.Core.Models;
using Sakamoto.TCC2.CSU.MedicalRecord.Domain.Validations;

namespace Sakamoto.TCC2.CSU.MedicalRecord.Domain.Models
{
    public class Patient : Entity
    {
        private Patient()
        {
        }

        public Patient(Guid id, string fullName)
        {
            Id = id;
            FullName = fullName;
        }

        public string FullName { get; }

        public override bool IsValid()
        {
            ValidationResult = new PatientValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}