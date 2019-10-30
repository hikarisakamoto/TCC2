using System;
using Dapper;
using Microsoft.EntityFrameworkCore;
using Sakamoto.TCC2.CSU.Patients.Domain.Interfaces;
using Sakamoto.TCC2.CSU.Patients.Domain.Models;
using Sakamoto.TCC2.CSU.Patients.Infrastructure.Data.Context;

namespace Sakamoto.TCC2.CSU.Patients.Infrastructure.Data.Repositories
{
    public class PatientRepository : Repository<Patient>, IPatientRepository
    {
        public PatientRepository(PatientContext context) : base(context)
        {
        }

        public Patient GetByCpf(string patientCpf)
        {
            const string sql = "SELECT * FROM PATIENTS P WHERE P.CPF LIKE '%@patientCpf%'";
            return Context.Database.GetDbConnection().QueryFirstOrDefault<Patient>(sql, new {patientCpf});
        }

        public override Patient GetById(Guid id)
        {
            const string sql = "SELECT * FROM PATIENTS P WHERE P.ID = @id";
            return Context.Database.GetDbConnection().QueryFirstOrDefault<Patient>(sql, new {id});
        }
    }
}