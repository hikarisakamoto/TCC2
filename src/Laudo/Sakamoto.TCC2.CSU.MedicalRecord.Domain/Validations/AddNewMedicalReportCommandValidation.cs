using Sakamoto.TCC2.CSU.MedicalRecord.Domain.Commands;

namespace Sakamoto.TCC2.CSU.MedicalRecord.Domain.Validations
{
    public class AddNewMedicalReportCommandValidation : MedicalReportCommandValidation<AddNewMedicalReportCommand>
    {
        public AddNewMedicalReportCommandValidation()
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