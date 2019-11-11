using System.Collections.Generic;
using Sakamoto.TCC2.CSU.Patients.Domain.Models;

namespace Sakamoto.TCC2.CSU.Patients.Domain.Interfaces
{
    public interface IPatientRepository : IRepository<Patient>
    {
        IEnumerable<Patient> GetAllPatients();
        Patient GetByCpf(string patientCpf);
    }
}