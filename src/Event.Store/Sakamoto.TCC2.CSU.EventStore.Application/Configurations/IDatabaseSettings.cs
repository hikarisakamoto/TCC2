namespace Sakamoto.TCC2.CSU.EventStore.Application.Configurations
{
    public interface IDatabaseSettings
    {
        string CollectionName { get; set; }
        string Connection { get; set; }
        string DatabaseName { get; set; }
    }
}