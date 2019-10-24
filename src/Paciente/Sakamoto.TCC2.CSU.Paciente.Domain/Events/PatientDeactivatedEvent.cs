using System;
using Sakamoto.TCC2.CSU.Domain.Core.Events;
using Sakamoto.TCC2.CSU.Patients.Domain.ValueObjects;
using Sakamoto.TCC2.CSU.Patients.Domain.ValueObjects.Enums;

namespace Sakamoto.TCC2.CSU.Patients.Domain.Events
{
    public class PatientDeactivatedEvent : Event
    {
        public PatientDeactivatedEvent(Guid id, string fullName, DateTime birthDate, string cpf, Gender gender,
            string email, string phone, byte[] photo, Address address, bool isActive)
        {
            Id = id;
            FullName = fullName;
            BirthDate = birthDate;
            Cpf = cpf;
            Gender = gender;
            Email = email;
            Phone = phone;
            Photo = photo;
            Address = address;
            IsActive = isActive;
            AggregateId = id;
        }

        public Guid Id { get; }
        public string FullName { get; }
        public DateTime BirthDate { get; }
        public string Cpf { get; }
        public Gender Gender { get; }
        public string Email { get; }
        public string Phone { get; }
        public byte[] Photo { get; }
        public Address Address { get; }
        public bool IsActive { get; }
    }
}