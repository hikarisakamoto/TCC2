using Sakamoto.TCC2.CSU.Domain.Core.Events;

namespace Sakamoto.TCC2.CSU.MedicalRecord.Domain.Events
{
    public class MedicalReportAddedEvent : Event
    {
        public MedicalReportAddedEvent(Models.MedicalRecord medicalRecord)
        {
            MedicalRecord = medicalRecord;
            AggregateId = medicalRecord.Id;
        }

        public Models.MedicalRecord MedicalRecord { get; }
    }
}