using System;
using System.ComponentModel.DataAnnotations;

namespace Sakamoto.TCC2.CSU.Web.Models.Practitioners
{
    public class UpdatePractitionerPhoneViewModel
    {
        [Required(ErrorMessage = "CRM is required")]
        [MaxLength(30)]
        public string CRM { get; set; }

        [Key] public Guid Id { get; set; }


        [Required(ErrorMessage = "Phone is required")]
        [MaxLength(20)]
        public string Phone { get; set; }
    }
}