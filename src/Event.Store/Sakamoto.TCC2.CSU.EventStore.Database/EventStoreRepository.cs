using System;
using System.Collections.Generic;
using AutoMapper;
using MongoDB.Bson;
using MongoDB.Driver;
using Sakamoto.TCC2.CSU.Domain.Core.Events;
using Sakamoto.TCC2.CSU.EventStore.Application.Configurations;
using Sakamoto.TCC2.CSU.EventStore.Application.Interfaces;
using Sakamoto.TCC2.CSU.EventStore.Application.Models;

namespace Sakamoto.TCC2.CSU.EventStore.Database
{
    public class EventStoreRepository : IEventStoreRepository, IDisposable
    {
        private readonly IMongoCollection<StoredEvents> _dbSet;
        private readonly IMapper _mapper;

        public EventStoreRepository(IDatabaseSettings databaseSettings, IMapper mapper)
        {
            _mapper = mapper;
            BsonDefaults.GuidRepresentation = GuidRepresentation.CSharpLegacy;
            IMongoClient client = new MongoClient(databaseSettings.Connection);
            var mongoDatabase = client.GetDatabase(databaseSettings.DatabaseName);
            _dbSet = mongoDatabase.GetCollection<StoredEvents>(databaseSettings.CollectionName);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public IList<StoredEvent> All(Guid aggregateId)
        {
            return _mapper.Map<IList<StoredEvent>>(_dbSet.Find(mr => mr.Id.Equals(aggregateId)));
        }

        public void Save<T>(T theEvent) where T : class
        {
            var storedEvent = _mapper.Map<StoredEvents>(theEvent);
            _dbSet.InsertOne(storedEvent);
        }
    }
}