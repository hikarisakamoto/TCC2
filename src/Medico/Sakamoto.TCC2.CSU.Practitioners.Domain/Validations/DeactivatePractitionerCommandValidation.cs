using Sakamoto.TCC2.CSU.Practitioners.Domain.Commands;

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