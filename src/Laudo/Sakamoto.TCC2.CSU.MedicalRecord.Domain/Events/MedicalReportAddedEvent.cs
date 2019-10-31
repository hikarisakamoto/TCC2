using Sakamoto.TCC2.CSU.Domain.Core.Events;
using Sakamoto.TCC2.CSU.MedicalRecord.Domain.Models;

namespace Sakamoto.TCC2.CSU.MedicalRecord.Domain.Events
{
    public class MedicalReportAddedEvent : Event
    {
        public MedicalReportAddedEvent(MedicalReport medicalReport)
        {
            MedicalReport = medicalReport;
            AggregateId = medicalReport.Id;
        }

        public MedicalReport MedicalReport { get; }
    }
}