using System;
using Sakamoto.TCC2.CSU.Patients.Domain.Validations;
using Sakamoto.TCC2.CSU.Patients.Domain.ValueObjects;

namespace Sakamoto.TCC2.CSU.Patients.Domain.Commands
{
    public class UpdatePatientCommand : PatientCommand
    {
        public UpdatePatientCommand(Guid id, string email, Address address, byte[] photo, string phone)
        {
            Email = email;
            Address = address;
            Photo = photo;
            Phone = phone;
            Id = id;
        }

        public string Email { get; }
        public Address Address { get; }
        public byte[] Photo { get; }

        public override bool IsValid()
        {
            ValidationResult = new UpdatePatientCommandValidation().Validate(this);

            return ValidationResult.IsValid;
        }
    }
}