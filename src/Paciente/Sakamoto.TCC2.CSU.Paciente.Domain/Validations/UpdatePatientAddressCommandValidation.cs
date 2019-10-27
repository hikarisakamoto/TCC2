using FluentValidation;
using Sakamoto.TCC2.CSU.Patients.Domain.Commands;

namespace Sakamoto.TCC2.CSU.Patients.Domain.Validations
{
    public class UpdatePatientAddressCommandValidation : PatientValidation<UpdatePatientAddressCommand>
    {
        public UpdatePatientAddressCommandValidation()
        {
            ValidateId();
            ValidateAddress();
        }

        private void ValidateAddress()
        {
            RuleFor(p => p.Address).Must(a => a.IsValid()).WithMessage("Address has invalid information.");
        }
    }
}