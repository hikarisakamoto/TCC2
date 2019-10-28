using System;
using System.ComponentModel.DataAnnotations;

namespace Sakamoto.TCC2.CSU.Patient.Application.ViewModels
{
    public class UpdatePatientPhoneViewModel
    {
        [Key] public Guid Id { get; set; }

        [Required(ErrorMessage = "Phone is required")]
        [MaxLength(20)]
        public string Phone { get; set; }
    }
}