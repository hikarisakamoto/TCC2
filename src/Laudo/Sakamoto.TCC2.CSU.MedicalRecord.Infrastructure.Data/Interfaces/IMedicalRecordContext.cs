using System;
using MongoDB.Driver;

namespace Sakamoto.TCC2.CSU.MedicalRecord.Infrastructure.Data.Interfaces
{
    public interface IMedicalRecordContext : IDisposable
    {
        IMongoDatabase GetMongoDatabase();
    }
}