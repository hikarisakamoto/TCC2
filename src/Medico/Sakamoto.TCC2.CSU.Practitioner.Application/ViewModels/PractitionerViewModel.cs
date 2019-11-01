using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Sakamoto.TCC2.CSU.Practitioner.Application.ViewModels
{
    public class PractitionerViewModel
    {
        [Required(ErrorMessage = "CRM is required")]
        [MaxLength(30)]
        public string CRM { get; set; }

        [Required(ErrorMessage = "An e-mail is required")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Expertise is required")]
        [MaxLength(300)]
        public string Expertise { get; set; }

        [Required(ErrorMessage = "Full name is required")]
        [MinLength(2)]
        [MaxLength(150)]
        [DisplayName("Full Name")]
        public string FullName { get; set; }

        [Key] public Guid Id { get; set; }

        public bool IsActive { get; set; }

        [Required(ErrorMessage = "Phone is required")]
        [MaxLength(20)]
        public string Phone { get; set; }
    }
}