using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Sakamoto.TCC2.CSU.Web.Models.MedicalRecord
{
    public class MedicalRecordViewModel
    {
        public DateTime Date { get; set; }

        [Key] public Guid Id { get; set; }

        public byte[] Image { get; set; }

        [Required(ErrorMessage = "Long description is required")]
        [MinLength(30)]
        [DisplayName("Long Description")]
        public string LongDescription { get; set; }

        public MedicalRecordPatientViewModel Patient { get; set; }

        public MedicalRecordPractitionerViewModel Practitioner { get; set; }

        [Required(ErrorMessage = "Short description is required")]
        [MinLength(30)]
        [MaxLength(300)]
        [DisplayName("Short Description")]
        public string ShortDescription { get; set; }
    }
}