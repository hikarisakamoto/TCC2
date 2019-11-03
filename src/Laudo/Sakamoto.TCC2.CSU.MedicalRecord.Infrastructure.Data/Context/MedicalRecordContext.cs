using System;
using MongoDB.Bson;
using MongoDB.Driver;
using Sakamoto.TCC2.CSU.MedicalRecord.Infrastructure.Data.Interfaces;

namespace Sakamoto.TCC2.CSU.MedicalRecord.Infrastructure.Data.Context
{
    public class MedicalRecordContext : IMedicalRecordContext
    {
        private readonly IMongoClient _client;
        private readonly IMongoDatabase _mongoDatabase;


        public MedicalRecordContext(IDatabaseSettings databaseSettings)
        {
            BsonDefaults.GuidRepresentation = GuidRepresentation.CSharpLegacy;
            _client = new MongoClient(databaseSettings.Connection);
            _mongoDatabase = _client.GetDatabase(databaseSettings.DatabaseName);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public IMongoClient GetMongoClient()
        {
            return _client;
        }

        public IMongoDatabase GetMongoDatabase()
        {
            return _mongoDatabase;
        }
    }
}