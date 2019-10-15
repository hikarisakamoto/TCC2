using System;
using FluentValidation.Results;
using Sakamoto.TCC2.CSU.Domain.Core.Events;

namespace Sakamoto.TCC2.CSU.Domain.Core.Commands
{
    public abstract class Command : Message
    {
        protected Command()
        {
            TimeStamp = DateTime.Now;
        }

        public DateTime TimeStamp { get; }
        public ValidationResult ValidationResult { get; protected set; }

        public abstract bool IsValid();
    }
}