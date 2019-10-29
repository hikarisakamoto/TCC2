using System;
using Sakamoto.TCC2.CSU.Practitioners.Domain.Validations;

namespace Sakamoto.TCC2.CSU.Practitioners.Domain.Commands
{
    public class UpdatePractitionerEmailCommand : PractitionerCommand
    {
        public UpdatePractitionerEmailCommand(Guid id, string email)
        {
            Id = id;
            Email = email;
        }

        public string Email { get; }

        public override bool IsValid()
        {
            ValidationResult = new UpdatePractitionerEmailCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}