using System;
using MediatR;

namespace Sakamoto.TCC2.CSU.Domain.Core.Events
{
    public abstract class Message : IRequest<bool>
    {
        protected Message()
        {
            MessageType = GetType().Name;
        }

        public Guid AggregateId { get; protected set; }

        public string MessageType { get; protected set; }
    }
}