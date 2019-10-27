using FluentValidation;
using Sakamoto.TCC2.CSU.Patients.Domain.Commands;

namespace Sakamoto.TCC2.CSU.Patients.Domain.Validations
{
    public class UpdatePatientHeartRateCommandValidation : PatientValidation<UpdatePatientHeartRateCommand>
    {
        public UpdatePatientHeartRateCommandValidation()
        {
            ValidateId();
            ValidateHeartRate();
        }

        private void ValidateHeartRate()
        {
            RuleFor(p => p.HeartRate)
                .GreaterThanOrEqualTo(0).WithMessage("Heart rate can't be a negative value.")
                .LessThanOrEqualTo(500).WithMessage("Heart rate can't be more than 500.");
        }
    }
}