using System;
using Dapper;
using Microsoft.EntityFrameworkCore;
using Sakamoto.TCC2.CSU.Patients.Domain.Interfaces;
using Sakamoto.TCC2.CSU.Patients.Domain.Models;
using Sakamoto.TCC2.CSU.Patients.Infrastructure.Data.Context;

namespace Sakamoto.TCC2.CSU.Patients.Infrastructure.Data.Repository
{
    public class PatientRepository : Repository<Patient>, IPatientRepository
    {
        public PatientRepository(PatientContext context, DbSet<Patient> dbSet) : base(context, dbSet)
        {
        }

        public Patient GetByCpf(string patientCpf)
        {
            var sql = $"SELECT * FROM PATIENTS P WHERE P.CPF LIKE '%{patientCpf}%'";
            return Context.Database.GetDbConnection().QueryFirstOrDefault<Patient>(sql);
        }

        public override Patient GetById(Guid id)
        {
            var sql = $"SELECT * FROM PATIENTS P WHERE P.ID = {id}";
            return Context.Database.GetDbConnection().QueryFirstOrDefault<Patient>(sql);
        }
    }
}