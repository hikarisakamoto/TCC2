using Sakamoto.TCC2.CSU.MedicalRecord.Domain.Commands;

namespace Sakamoto.TCC2.CSU.MedicalRecord.Domain.Validations
{
    public class AddNewMedicalRecordCommandValidation : MedicalRecordCommandValidation<AddNewMedicalRecordCommand>
    {
        public AddNewMedicalRecordCommandValidation()
        {
            ValidateLongDescription();
            ValidatePatientId();
            ValidatePatientName();
            ValidatePractitionerId();
            ValidatePractitionerName();
            ValidateShortDescription();
        }
    }
}