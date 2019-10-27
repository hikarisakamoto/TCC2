using System;
using Sakamoto.TCC2.CSU.Patients.Domain.Validations;
using Sakamoto.TCC2.CSU.Patients.Domain.ValueObjects;

namespace Sakamoto.TCC2.CSU.Patients.Domain.Commands
{
    public class UpdatePatientAddressCommand : PatientCommand
    {
        public UpdatePatientAddressCommand(Guid id, Address address)
        {
            Id = id;
            Address = address;
        }

        public Address Address { get; }

        public override bool IsValid()
        {
            ValidationResult = new UpdatePatientAddressCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}