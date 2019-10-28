using System;
using System.ComponentModel.DataAnnotations;

namespace Sakamoto.TCC2.CSU.Patient.Application.ViewModels
{
    public class UpdatePatientEmailViewModel
    {
        [Required(ErrorMessage = "An e-mail is required")]
        [EmailAddress]
        public string Email { get; set; }

        [Key] public Guid Id { get; set; }
    }
}