using System;

namespace Sakamoto.TCC2.CSU.Web.Models.EventStore
{
    public class StoredEventViewModel
    {
        public Guid AggregateId { get; set; }

        public string Data { get; set; }

        public Guid Id { get; set; }

        public string MessageType { get; set; }

        public string User { get; set; }
    }
}