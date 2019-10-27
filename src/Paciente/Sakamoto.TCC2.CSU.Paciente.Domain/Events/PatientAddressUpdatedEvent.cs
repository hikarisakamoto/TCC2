using Sakamoto.TCC2.CSU.Domain.Core.Events;
using Sakamoto.TCC2.CSU.Patients.Domain.Models;

namespace Sakamoto.TCC2.CSU.Patients.Domain.Events
{
    public class PatientAddressUpdatedEvent : Event
    {
        public PatientAddressUpdatedEvent(Patient patient)
        {
            Patient = patient;
            AggregateId = patient.Id;
        }
        public Patient Patient { get; }

    }
}