using Sakamoto.TCC2.CSU.Patients.Domain.Commands;

namespace Sakamoto.TCC2.CSU.Patients.Domain.Validations
{
    public class RegisterNewPatientCommandValidation : PatientValidation<RegisterNewPatientCommand>
    {
        public RegisterNewPatientCommandValidation()
        {
            ValidateFullName();
            ValidadeCpf();
            ValidateBirthDate();
            ValidatePhone();
        }
    }
}