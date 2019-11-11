using System;
using System.ComponentModel.DataAnnotations;

namespace Sakamoto.TCC2.CSU.Web.Models.Practitioners
{
    public class UpdatePractitionerEmailViewModel
    {
        [Required(ErrorMessage = "CRM is required")]
        [MaxLength(30)]
        public string CRM { get; set; }

        [Required(ErrorMessage = "An e-mail is required")]
        [EmailAddress]
        public string Email { get; set; }

        [Key] public Guid Id { get; set; }
    }
}