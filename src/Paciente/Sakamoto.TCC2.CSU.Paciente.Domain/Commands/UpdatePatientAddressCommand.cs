using System;
using Sakamoto.TCC2.CSU.Patients.Domain.Validations;
using Sakamoto.TCC2.CSU.Patients.Domain.ValueObjects;

namespace Sakamoto.TCC2.CSU.Patients.Domain.Commands
{
    public class UpdatePatientAddressCommand : PatientCommand
    {

        public string City { get; }
        public string District { get; }
        public string Number { get; }

        public string Observation { get; }
        public string PostalCode { get; }
        public string State { get; }
        public string Street { get; }

        public UpdatePatientAddressCommand(Guid id, string city, string district, string number, string observation, string postalCode, string state, string street)
        {
            Id = id;
            City = city;
            District = district;
            Number = number;
            Observation = observation;
            PostalCode = postalCode;
            State = state;
            Street = street;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdatePatientAddressCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}