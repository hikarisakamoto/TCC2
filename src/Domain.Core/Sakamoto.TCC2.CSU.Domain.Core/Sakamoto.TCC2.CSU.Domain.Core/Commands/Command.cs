using System;
using FluentValidation.Results;
using Sakamoto.TCC2.CSU.Domain.Core.Events;

namespace Sakamoto.TCC2.CSU.Domain.Core.Commands
{
    public abstract class Command : Message
    {
        public DateTime TimeStamp { get; }
        public ValidationResult ValidationResult { get; protected set; }

        protected Command()
        {
            TimeStamp = DateTime.Now;
        }

        public abstract bool IsValid();
    }
}