using System.Linq;
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
            return Context.Patients.FirstOrDefault(p => p.Cpf.Value.Equals(patientCpf));
        }
    }
}