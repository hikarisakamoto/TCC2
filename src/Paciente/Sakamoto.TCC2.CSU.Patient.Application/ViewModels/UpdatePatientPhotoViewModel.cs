using System;
using System.ComponentModel.DataAnnotations;

namespace Sakamoto.TCC2.CSU.Patient.Application.ViewModels
{
    public class UpdatePatientPhotoViewModel
    {
        [Key] public Guid Id { get; set; }

        [Required(ErrorMessage = "Photo is required")]
        public byte[] Photo { get; set; }
    }
}