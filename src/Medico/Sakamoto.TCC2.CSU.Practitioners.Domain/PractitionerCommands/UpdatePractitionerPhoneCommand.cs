using System;
using Sakamoto.TCC2.CSU.Practitioners.Domain.Validations;

namespace Sakamoto.TCC2.CSU.Practitioners.Domain.PractitionerCommands
{
    public class UpdatePractitionerPhoneCommand : PractitionerCommand
    {
        public UpdatePractitionerPhoneCommand(Guid id, string phone)
        {
            Id = id;
            Phone = phone;
        }

        public string Phone { get; }

        public override bool IsValid()
        {
            ValidationResult = new UpdatePractitionerPhoneCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}