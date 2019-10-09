using System;

namespace Sakamoto.TCC2.CSU.Domain.Core.Events
{
    public class StoredEvent : Event
    {
        protected StoredEvent() { }

        public StoredEvent(Event @event, string data, string user)
        {
            Id = Guid.NewGuid();
            AggregateId = @event.AggregateId;
            MessageType = @event.MessageType;
            Data = data;
            User = user;
        }
        public Guid Id { get; }
        public string Data { get; }
        public string User { get; }
        // TODO ADD PROPRIETIES THAT MAKE SENSE TO ADD IN THE EVENT STORE (EVENT SOURCING)
    }
}