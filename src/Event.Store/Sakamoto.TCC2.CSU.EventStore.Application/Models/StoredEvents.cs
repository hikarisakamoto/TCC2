using System;
using MongoDB.Bson.Serialization.Attributes;

namespace Sakamoto.TCC2.CSU.EventStore.Application.Models
{
    public class StoredEvents
    {
        [BsonRequired] public Guid AggregateId { get; set; }

        [BsonRequired] public string Data { get; set; }

        [BsonId] public Guid Id { get; set; }

        [BsonRequired] public string MessageType { get; set; }

        [BsonRequired] public string User { get; set; }
    }
}