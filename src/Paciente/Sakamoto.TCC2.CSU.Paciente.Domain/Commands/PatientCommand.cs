using System;
using Sakamoto.TCC2.CSU.Domain.Core.Commands;
using Sakamoto.TCC2.CSU.Patients.Domain.ValueObjects;
using Sakamoto.TCC2.CSU.Patients.Domain.ValueObjects.Enums;

namespace Sakamoto.TCC2.CSU.Patients.Domain.Commands
{
    public abstract class PatientCommand : Command
    {
        public DateTime BirthDate { get; protected set; }
        public CPF Cpf { get; protected set; }
        public string FullName { get; protected set; }
        public Gender Gender { get; protected set; }
        public Guid Id { get; protected set; }
        public string Phone { get; protected set; }
    }
}