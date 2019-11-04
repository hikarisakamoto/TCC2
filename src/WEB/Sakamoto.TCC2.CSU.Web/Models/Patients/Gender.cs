using System.ComponentModel;

namespace Sakamoto.TCC2.CSU.Web.Models.Patients
{
    public enum Gender
    {
        [Description("Male")] Male,
        [Description("Famale")] Female,
        [Description("Other")] Other,
        [Description("Unknown")] Unknown
    }
}