using System;
using Sakamoto.TCC2.CSU.Patients.Domain.Validations;

namespace Sakamoto.TCC2.CSU.Patients.Domain.Commands
{
    public class UpdatePatientEmailCommand : PatientCommand
    {
        public UpdatePatientEmailCommand(Guid id, string email)
        {
            Id = id;
            Email = email;
        }

        public string Email { get; }

        public override bool IsValid()
        {
            ValidationResult = new UpdatePatientEmailCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}