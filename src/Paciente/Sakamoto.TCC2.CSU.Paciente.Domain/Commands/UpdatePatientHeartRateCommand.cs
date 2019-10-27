using System;
using Sakamoto.TCC2.CSU.Patients.Domain.Validations;

namespace Sakamoto.TCC2.CSU.Patients.Domain.Commands
{
    public class UpdatePatientHeartRateCommand : PatientCommand
    {
        public UpdatePatientHeartRateCommand(Guid id, int heartRate)
        {
            Id = id;
            HeartRate = heartRate;
        }

        public int HeartRate { get; }

        public override bool IsValid()
        {
            ValidationResult = new UpdatePatientHeartRateCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}