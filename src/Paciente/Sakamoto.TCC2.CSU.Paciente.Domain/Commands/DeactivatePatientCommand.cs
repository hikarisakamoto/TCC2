using System;
using Sakamoto.TCC2.CSU.Patients.Domain.Validations;

namespace Sakamoto.TCC2.CSU.Patients.Domain.Commands
{
    public class DeactivatePatientCommand : PatientCommand
    {
        public DeactivatePatientCommand(Guid id, string cpf)
        {
            Id = id;
            Cpf = cpf;
        }

        public override bool IsValid()
        {
            ValidationResult = new DeactivatePatientCommandValidation().Validate(this);

            return ValidationResult.IsValid;
        }
    }
}