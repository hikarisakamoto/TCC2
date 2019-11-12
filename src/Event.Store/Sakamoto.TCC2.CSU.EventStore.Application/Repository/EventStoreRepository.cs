using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;
using Sakamoto.TCC2.CSU.EventStore.Application.Configurations;
using Sakamoto.TCC2.CSU.EventStore.Application.Interfaces;
using Sakamoto.TCC2.CSU.EventStore.Application.Models;

namespace Sakamoto.TCC2.CSU.EventStore.Application.Repository
{
    public class EventStoreRepository : IEventStoreRepository, IDisposable
    {
        private readonly IMongoCollection<StoredEvents> _dbSet;

        public EventStoreRepository(IDatabaseSettings databaseSettings)
        {
            BsonDefaults.GuidRepresentation = GuidRepresentation.CSharpLegacy;
            IMongoClient client = new MongoClient(databaseSettings.Connection);
            var mongoDatabase = client.GetDatabase(databaseSettings.DatabaseName);
            _dbSet = mongoDatabase.GetCollection<StoredEvents>(databaseSettings.CollectionName);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public IEnumerable<Guid> All()
        {
            return _dbSet.Find(s => true).ToList().Select(e => e.AggregateId).Distinct();
        }

        public IList<StoredEvents> EventsByAggregate(Guid aggregateId)
        {
            return _dbSet.Find(mr => mr.Id.Equals(aggregateId)).ToList();
        }

        public void Save(StoredEvents theEvent)
        {
            _dbSet.InsertOne(theEvent);
        }
    }
}