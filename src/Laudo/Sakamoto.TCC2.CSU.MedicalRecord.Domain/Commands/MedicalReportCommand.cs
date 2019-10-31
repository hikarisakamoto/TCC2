using Sakamoto.TCC2.CSU.Domain.Core.Commands;
using Sakamoto.TCC2.CSU.MedicalRecord.Domain.Models;

namespace Sakamoto.TCC2.CSU.MedicalRecord.Domain.Commands
{
    public abstract class MedicalReportCommand : Command
    {
        public string LongDescription { get; protected set; }
        public Patient Patient { get; protected set; }
        public Practitioner Practitioner { get; protected set; }
        public string ShortDescription { get; protected set; }
    }
}