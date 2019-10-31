using Sakamoto.TCC2.CSU.Patients.Domain.Commands;

namespace Sakamoto.TCC2.CSU.Patients.Domain.Validations
{
    public class DeactivatePatientCommandValidation : PatientCommandValidation<DeactivatePatientCommand>
    {
        public DeactivatePatientCommandValidation()
        {
            ValidateId();
            ValidateCpf();
        }
    }
}