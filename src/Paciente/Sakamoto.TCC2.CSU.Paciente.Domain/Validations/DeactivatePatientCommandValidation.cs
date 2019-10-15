using Sakamoto.TCC2.CSU.Patients.Domain.Commands;

namespace Sakamoto.TCC2.CSU.Patients.Domain.Validations
{
    public class DeactivatePatientCommandValidation : PatientValidation<DeactivatePatientCommand>
    {
        public DeactivatePatientCommandValidation()
        {
            ValidateId();
            ValidadeCpf();
        }
    }
}