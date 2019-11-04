namespace Sakamoto.TCC2.CSU.EventStore.Application.Configurations
{
    public class DatabaseSettings : IDatabaseSettings
    {
        public string CollectionName { get; set; }
        public string Connection { get; set; }
        public string DatabaseName { get; set; }
    }
}