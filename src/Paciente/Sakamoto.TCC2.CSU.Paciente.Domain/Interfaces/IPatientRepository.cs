using Sakamoto.TCC2.CSU.Patients.Domain.Models;
using Sakamoto.TCC2.CSU.Patients.Domain.ValueObjects;

namespace Sakamoto.TCC2.CSU.Patients.Domain.Interfaces
{
    public interface IPatientRepository : IRepository<Patient>
    {
        Patient GetByCpf(string patientCpf);
    }
}