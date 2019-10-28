using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Sakamoto.TCC2.CSU.Patients.Domain.ValueObjects.Enums;

namespace Sakamoto.TCC2.CSU.Patient.Application.ViewModels
{
    public class RegisterNewPatientViewModel
    {
        [Required(ErrorMessage = "Birth Date is required")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date, ErrorMessage = "Invalid format")]
        [DisplayName("Birth Date")]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "CPF is required")]
        [DisplayName("CPF")]
        [StringLength(11)]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "Full name is required")]
        [MinLength(2)]
        [MaxLength(100)]
        [DisplayName("Full Name")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        public Gender Gender { get; set; }

        [Key] public Guid Id { get; set; }

        [Required(ErrorMessage = "Phone is required")]
        [MaxLength(20)]
        public string Phone { get; set; }
    }
}