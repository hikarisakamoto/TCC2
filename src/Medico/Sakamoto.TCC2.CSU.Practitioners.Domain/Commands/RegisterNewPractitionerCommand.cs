using System;
using Sakamoto.TCC2.CSU.Practitioners.Domain.Validations;

namespace Sakamoto.TCC2.CSU.Practitioners.Domain.Commands
{
    public class RegisterNewPractitionerCommand : PractitionerCommand
    {
        public RegisterNewPractitionerCommand(string fullName, string expertise, string phone, string email, string crm)
        {
            Id = Guid.NewGuid();
            FullName = fullName;
            Expertise = expertise;
            Phone = phone;
            Email = email;
            CRM = crm;
        }

        public string CRM { get; }
        public string Email { get; }
        public string Expertise { get; }

        public string FullName { get; }
        public string Phone { get; }

        public override bool IsValid()
        {
            ValidationResult = new RegisterNewPractitionerCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}