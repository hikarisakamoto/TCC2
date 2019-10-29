using System;
using Sakamoto.TCC2.CSU.Domain.Core.Commands;

namespace Sakamoto.TCC2.CSU.Practitioners.Domain.Commands
{
    public abstract class PractitionerCommand : Command
    {
        public Guid Id { get; protected set; }
    }
}