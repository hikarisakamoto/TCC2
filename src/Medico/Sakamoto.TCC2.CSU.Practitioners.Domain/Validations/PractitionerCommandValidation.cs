using System;
using FluentValidation;
using Sakamoto.TCC2.CSU.Practitioners.Domain.Commands;

namespace Sakamoto.TCC2.CSU.Practitioners.Domain.Validations
{
    public class PractitionerCommandValidation<T> : AbstractValidator<T> where T : PractitionerCommand
    {
        protected void ValidateId()
        {
            RuleFor(p => p.Id)
                .NotEqual(Guid.Empty);
        }
    }
}