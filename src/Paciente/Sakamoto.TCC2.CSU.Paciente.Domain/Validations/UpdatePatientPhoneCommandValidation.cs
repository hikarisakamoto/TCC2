using Sakamoto.TCC2.CSU.Patients.Domain.Commands;

namespace Sakamoto.TCC2.CSU.Patients.Domain.Validations
{
    public class UpdatePatientPhoneCommandValidation : PatientValidation<UpdatePatientPhoneCommand>
    {
        public UpdatePatientPhoneCommandValidation()
        {
            ValidateId();
            ValidatePhone();
        }
    }
}