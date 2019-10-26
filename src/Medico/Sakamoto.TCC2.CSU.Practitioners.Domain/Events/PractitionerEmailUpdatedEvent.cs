using Sakamoto.TCC2.CSU.Domain.Core.Events;
using Sakamoto.TCC2.CSU.Practitioners.Domain.Models;

namespace Sakamoto.TCC2.CSU.Practitioners.Domain.Events
{
    public class PractitionerEmailUpdatedEvent : Event
    {
        public PractitionerEmailUpdatedEvent(Practitioner practitioner)
        {
            Practitioner = practitioner;
            AggregateId = practitioner.Id;
        }

        public Practitioner Practitioner { get; }
    }
}