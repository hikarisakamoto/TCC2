using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Sakamoto.TCC2.CSU.MedicalRecord.Application.ViewModel
{
    public class PractitionerViewModel
    {
        [Required(ErrorMessage = "Practitioner name is required")]
        [MinLength(2)]
        [MaxLength(150)]
        [DisplayName("Practitioner Name")]
        public string FullName { get; set; }

        [Key]
        [Required(ErrorMessage = "Practitioner ID is required")]
        public Guid PractitionerId { get; set; }
    }
}