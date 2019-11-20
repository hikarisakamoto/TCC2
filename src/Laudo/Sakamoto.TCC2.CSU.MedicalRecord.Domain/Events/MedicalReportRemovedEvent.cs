using System;
using Sakamoto.TCC2.CSU.Domain.Core.Events;

namespace Sakamoto.TCC2.CSU.MedicalRecord.Domain.Events
{
    public class MedicalReportRemovedEvent : Event
    {
        public MedicalReportRemovedEvent(Guid medicalReportId, Guid patientId, Guid practitionerId)
        {
            MedicalReportId = medicalReportId;
            PatientId = patientId;
            PractitionerId = practitionerId;
            AggregateId = patientId;
        }

        public Guid MedicalReportId { get; }
        public Guid PatientId { get; }
        public Guid PractitionerId { get; }
    }
}