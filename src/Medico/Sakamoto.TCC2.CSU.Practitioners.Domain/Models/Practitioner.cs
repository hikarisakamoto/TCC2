using System;
using Sakamoto.TCC2.CSU.Domain.Core.Models;
using Sakamoto.TCC2.CSU.Practitioners.Domain.Validations;

namespace Sakamoto.TCC2.CSU.Practitioners.Domain.Models
{
    public class Practitioner : Entity
    {
        protected Practitioner()
        {
        }

        public string CRM { get; private set; }
        public string Email { get; private set; }
        public string Expertise { get; private set; }

        public string FullName { get; private set; }
        public bool IsActive { get; private set; }
        public string Phone { get; private set; }

        public override bool IsValid()
        {
            ValidationResult = new PractitionerValidation().Validate(this);

            return ValidationResult.IsValid;
        }

        public class Builder
        {
            private readonly Practitioner _practitioner;

            public Builder(Guid id)
            {
                _practitioner = new Practitioner {Id = id};
            }

            public Practitioner Build()
            {
                return _practitioner;
            }

            public Builder Named(string fullName)
            {
                _practitioner.FullName = fullName;
                return this;
            }

            public Builder WhichIsActive()
            {
                _practitioner.IsActive = true;
                return this;
            }

            public Builder WhichIsInactive()
            {
                _practitioner.IsActive = false;
                return this;
            }

            public Builder WithCrm(string crm)
            {
                _practitioner.CRM = crm;
                return this;
            }

            public Builder WithEmail(string email)
            {
                _practitioner.Email = email;
                return this;
            }

            public Builder WithExpertiseIn(string expertise)
            {
                _practitioner.Expertise = expertise;
                return this;
            }

            public Builder WithPhone(string phone)
            {
                _practitioner.Phone = phone;
                return this;
            }
        }
    }
}