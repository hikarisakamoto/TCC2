using Sakamoto.TCC2.CSU.Domain.Core.Models;
using Sakamoto.TCC2.CSU.Patients.Domain.Validations;

namespace Sakamoto.TCC2.CSU.Patients.Domain.ValueObjects
{
    public class Address : ValueObject<Address>
    {
        protected Address()
        {
        }

        public string Observation { get; private set; }
        public string Street { get; private set; }
        public string City { get; private set; }
        public string Number { get; private set; }
        public string District { get; private set; }
        public string State { get; private set; }
        public string PostalCode { get; private set; }

        public override bool IsValid()
        {
            ValidationResult = new AddressValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        public class Builder
        {
            private readonly Address _address = new Address();

            public Builder WithStreet(string street)
            {
                _address.Street = street;
                return this;
            }

            public Builder InCityOf(string city)
            {
                _address.City = city;
                return this;
            }

            public Builder WithNumber(string number)
            {
                _address.Number = number;
                return this;
            }

            public Builder InTheDistrict(string district)
            {
                _address.District = district;
                return this;
            }

            public Builder InTheState(string state)
            {
                _address.State = state;
                return this;
            }

            public Builder WithPostalCode(string postalCode)
            {
                _address.PostalCode = postalCode;
                return this;
            }

            public Builder WithObservation(string observation)
            {
                _address.Observation = observation;
                return this;
            }

            public Address Build()
            {
                return _address;
            }
        }
    }
}