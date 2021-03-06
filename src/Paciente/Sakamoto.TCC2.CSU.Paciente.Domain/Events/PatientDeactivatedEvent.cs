﻿using Sakamoto.TCC2.CSU.Domain.Core.Events;
using Sakamoto.TCC2.CSU.Patients.Domain.Models;

namespace Sakamoto.TCC2.CSU.Patients.Domain.Events
{
    public class PatientDeactivatedEvent : Event
    {
        public PatientDeactivatedEvent(Patient patient)
        {
            Patient = patient;
            AggregateId = patient.Id;
        }

        public Patient Patient { get; }
    }
}