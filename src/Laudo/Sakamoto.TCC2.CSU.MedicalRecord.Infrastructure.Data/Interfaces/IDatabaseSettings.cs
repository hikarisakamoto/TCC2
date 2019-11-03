namespace Sakamoto.TCC2.CSU.MedicalRecord.Infrastructure.Data.Interfaces
{
    public interface IDatabaseSettings
    {
        string CollectionName { get; set; }
        string Connection { get; set; }
        string DatabaseName { get; set; }

    }
}