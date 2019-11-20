using Sakamoto.TCC2.CSU.Domain.Core.Events;

namespace Sakamoto.TCC2.CSU.MedicalRecord.Domain.Events
{
    public class MedicalReportWithImageAddedEvent : Event
    {
        public MedicalReportWithImageAddedEvent(Models.MedicalRecord medicalRecord)
        {
            MedicalRecord = medicalRecord;
            AggregateId = medicalRecord.PatientId;
        }

        public Models.MedicalRecord MedicalRecord { get; }
    }
}