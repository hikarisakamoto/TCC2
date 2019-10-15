using Sakamoto.TCC2.CSU.Patients.Domain.Models;

namespace Sakamoto.TCC2.CSU.Patients.Domain.Interfaces
{
    public interface IPatientRepository : IRepository<Patient>
    {
        Patient GetByCpf(string patientCpf);
    }
}