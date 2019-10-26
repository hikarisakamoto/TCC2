using FluentValidation;
using Sakamoto.TCC2.CSU.Practitioners.Domain.ValueObjects;

namespace Sakamoto.TCC2.CSU.Practitioners.Domain.Validations
{
    public class AddressValidation : AbstractValidator<Address>
    {
        public AddressValidation()
        {
            ValidateCity();
            ValidateDistrict();
            ValidatePostalCode();
            ValidateNumber();
            ValidateState();
            ValidateStreet();
        }

        private void ValidateCity()
        {
            RuleFor(a => a.City).NotEmpty().NotNull().WithMessage("Please fill in the city name.")
                .Length(2, 200)
                .WithMessage("The city name must be between 2 and 200 characters.");
        }

        private void ValidateDistrict()
        {
            RuleFor(a => a.District)
                .NotEmpty().NotNull().WithMessage("Please fill in the district information.")
                .Length(2, 150).WithMessage("The district name must be between 2 and 150 characters.");
        }

        private void ValidateNumber()
        {
            RuleFor(a => a.Number)
                .NotEmpty().NotNull().WithMessage("Please fill the number information.");
        }

        private void ValidatePostalCode()
        {
            RuleFor(a => a.PostalCode)
                .NotEmpty().NotNull().WithMessage("Please fill in the postal code information.")
                .Length(8).WithMessage("Postal code must be 8 digits");
        }

        private void ValidateState()
        {
            RuleFor(a => a.State).NotEmpty().NotNull().WithMessage("Please fill in the state information.")
                .Length(2, 150).WithMessage("The state name must be between 2 and 150 characters.");
        }

        private void ValidateStreet()
        {
            RuleFor(a => a.Street)
                .NotEmpty().NotNull().WithMessage("Please fill the street information.");
        }
    }
}