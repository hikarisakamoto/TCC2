﻿using System;
using Sakamoto.TCC2.CSU.Domain.Core.Models;
using Sakamoto.TCC2.CSU.Patients.Domain.Validations;
using Sakamoto.TCC2.CSU.Patients.Domain.ValueObjects;
using Sakamoto.TCC2.CSU.Patients.Domain.ValueObjects.Enums;

namespace Sakamoto.TCC2.CSU.Patients.Domain.Models
{
    public class Patient : Entity
    {
        protected Patient()
        {
        }

        public Address Address { get; private set; }
        public DateTime BirthDate { get; private set; }
        public string Cpf { get; private set; }
        public string Email { get; private set; }
        public string FullName { get; private set; }
        public Gender Gender { get; private set; }
        public int HeartRate { get; private set; }
        public bool IsActive { get; private set; }
        public string Phone { get; private set; }
        public byte[] Photo { get; private set; }

        public override bool IsValid()
        {
            ValidationResult = new PatientValidation().Validate(this);

            return ValidationResult.IsValid;
        }

        public class Builder
        {
            private readonly Patient _patient;

            public Builder(Guid id)
            {
                _patient = new Patient {Id = id};
            }

            public Builder BornIn(DateTime birthDate)
            {
                _patient.BirthDate = birthDate;
                return this;
            }

            public Patient Build()
            {
                return _patient;
            }

            public Builder Named(string fullName)
            {
                _patient.FullName = fullName;
                return this;
            }

            public Builder ThatLivesIn(Address address)
            {
                _patient.Address = address;
                return this;
            }

            public Builder WhichIsActive()
            {
                _patient.IsActive = true;
                return this;
            }

            public Builder WhichIsInactive()
            {
                _patient.IsActive = false;
                return this;
            }

            public Builder WithCpf(string cpf)
            {
                _patient.Cpf = cpf;
                return this;
            }

            public Builder WithEmail(string email)
            {
                _patient.Email = email;
                return this;
            }

            public Builder WithGender(Gender gender)
            {
                _patient.Gender = gender;
                return this;
            }

            public Builder WithHeartRate(int heartRate)
            {
                _patient.HeartRate = heartRate;
                return this;
            }

            public Builder WithPhone(string phone)
            {
                _patient.Phone = phone;
                return this;
            }

            public Builder WithPhoto(byte[] photo)
            {
                _patient.Photo = photo;
                return this;
            }
        }
    }
}