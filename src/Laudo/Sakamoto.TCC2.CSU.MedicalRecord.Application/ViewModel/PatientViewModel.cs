using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Sakamoto.TCC2.CSU.MedicalRecord.Application.ViewModel
{
    public class PatientViewModel
    {
        [Required(ErrorMessage = "Patient name is required")]
        [MinLength(2)]
        [MaxLength(150)]
        [DisplayName("Patient Name")]
        public string FullName { get; set; }

        [Key]
        [Required(ErrorMessage = "Patient ID is required")]
        public Guid PatientId { get; set; }
    }
}