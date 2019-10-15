using System;
using MediatR;

namespace Sakamoto.TCC2.CSU.Domain.Core.Events
{
    public abstract class Event : Message, INotification
    {
        protected Event()
        {
            TimeStamp = DateTime.Now;
        }

        public DateTime TimeStamp { get; }
    }
}