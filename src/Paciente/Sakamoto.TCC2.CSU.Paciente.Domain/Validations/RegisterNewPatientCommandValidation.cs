using Sakamoto.TCC2.CSU.Patients.Domain.Commands;

namespace Sakamoto.TCC2.CSU.Patients.Domain.Validations
{
    public class RegisterNewPatientCommandValidation : PatientCommandValidation<RegisterNewPatientCommand>
    {
        public RegisterNewPatientCommandValidation()
        {
            ValidateFullName();
            ValidateCpf();
            ValidateBirthDate();
            ValidatePhone();
        }
    }
}