using Sakamoto.TCC2.CSU.Patients.Domain.Commands;

namespace Sakamoto.TCC2.CSU.Patients.Domain.Validations
{
    public class UpdatePatientPhoneCommandValidation : PatientCommandValidation<UpdatePatientPhoneCommand>
    {
        public UpdatePatientPhoneCommandValidation()
        {
            ValidateId();
            ValidatePhone();
        }
    }
}