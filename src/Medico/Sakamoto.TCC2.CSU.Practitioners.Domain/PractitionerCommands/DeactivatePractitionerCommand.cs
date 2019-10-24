using System;
using Sakamoto.TCC2.CSU.Practitioners.Domain.Validations;

namespace Sakamoto.TCC2.CSU.Practitioners.Domain.PractitionerCommands
{
    public class DeactivatePractitionerCommand : PractitionerCommand
    {
        public DeactivatePractitionerCommand(Guid id)
        {
            Id = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new DeactivatePractitionerCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}