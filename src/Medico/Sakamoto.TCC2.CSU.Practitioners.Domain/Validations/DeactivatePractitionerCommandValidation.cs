using Sakamoto.TCC2.CSU.Practitioners.Domain.PractitionerCommands;

namespace Sakamoto.TCC2.CSU.Practitioners.Domain.Validations
{
    public class DeactivatePractitionerCommandValidation : PractitionerCommandValidation<DeactivatePractitionerCommand>
    {
        public DeactivatePractitionerCommandValidation()
        {
            ValidateId();
        }
    }
}