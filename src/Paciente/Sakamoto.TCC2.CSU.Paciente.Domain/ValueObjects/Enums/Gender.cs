using System.ComponentModel;

namespace Sakamoto.TCC2.CSU.Patients.Domain.ValueObjects.Enums
{
    public enum Gender
    {
        [Description("Male")]
        Male,
        [Description("Famale")]
        Female,
        [Description("Other")]
        Other,
        [Description("Unknown")]
        Unknown
    }
}