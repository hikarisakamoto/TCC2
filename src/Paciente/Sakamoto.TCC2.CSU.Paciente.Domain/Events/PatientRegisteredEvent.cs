using System;
using Sakamoto.TCC2.CSU.Domain.Core.Events;
using Sakamoto.TCC2.CSU.Patients.Domain.ValueObjects.Enums;

namespace Sakamoto.TCC2.CSU.Patients.Domain.Events
{
    public class PatientRegisteredEvent : Event
    {
        public Guid Id { get; }
        public string FullName { get; }
        public DateTime BirthDate { get; }
        public Gender Gender { get; }
        public string Phone { get; }

        public PatientRegisteredEvent(Guid id, string fullName, in DateTime birthDate, string cpfValue, Gender gender, string phone)
        {
            Id = id;
            FullName = fullName;
            BirthDate = birthDate;
            Gender = gender;
            Phone = phone;
            AggregateId = id;
        }
    }
}