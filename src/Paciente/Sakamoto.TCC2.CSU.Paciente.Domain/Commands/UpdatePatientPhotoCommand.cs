using System;
using Sakamoto.TCC2.CSU.Patients.Domain.Validations;

namespace Sakamoto.TCC2.CSU.Patients.Domain.Commands
{
    public class UpdatePatientPhotoCommand : PatientCommand
    {
        public UpdatePatientPhotoCommand(Guid id, byte[] photo)
        {
            Id = id;
            Photo = photo;
        }

        public byte[] Photo { get; }

        public override bool IsValid()
        {
            ValidationResult = new UpdatePatientPhotoCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}