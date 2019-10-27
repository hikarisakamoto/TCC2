using System;
using Sakamoto.TCC2.CSU.Patients.Domain.Validations;

namespace Sakamoto.TCC2.CSU.Patients.Domain.Commands
{
    public class UpdatePatientPhoneCommand : PatientCommand
    {
        public UpdatePatientPhoneCommand(Guid id, string phone)
        {
            Id = id;
            Phone = phone;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdatePatientPhoneCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}