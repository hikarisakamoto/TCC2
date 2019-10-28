using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Sakamoto.TCC2.CSU.Patient.Application.ViewModels
{
    public class PatientViewModel
    {
        public AddressViewModel Address { get; set; }

        [Required(ErrorMessage = "Birth Date is required")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date, ErrorMessage = "Invalid format")]
        [DisplayName("Birth Date")]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "CPF is required")]
        [DisplayName("CPF")]
        [StringLength(11)]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "An e-mail is required")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Full name is required")]
        [MinLength(2)]
        [MaxLength(100)]
        [DisplayName("Full Name")]
        public string FullName { get; set; }

        public int HeartRate { get; set; }
        [Key] public Guid Id { get; set; }

        public bool IsActive { get; set; }

        [Required(ErrorMessage = "Phone is required")]
        [MaxLength(20)]
        public string Phone { get; set; }

        public byte[] Photo { get; set; }
    }
}