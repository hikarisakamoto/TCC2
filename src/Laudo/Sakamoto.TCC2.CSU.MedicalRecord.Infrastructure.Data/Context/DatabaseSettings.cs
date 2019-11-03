using Sakamoto.TCC2.CSU.MedicalRecord.Infrastructure.Data.Interfaces;

namespace Sakamoto.TCC2.CSU.MedicalRecord.Infrastructure.Data.Context
{
    public class DatabaseSettings : IDatabaseSettings

    {
        public string Connection { get; set; }
        public string DatabaseName { get; set; }
        public string CollectionName { get; set; }
    }
}