using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Sakamoto.TCC2.CSU.Patient.Application.ViewModels
{
    public class DeactivatePatientViewModel
    {
        [Required(ErrorMessage = "CPF is required")]
        [DisplayName("CPF")]
        [StringLength(11)]
        public string Cpf { get; set; }

        [Key] public Guid Id { get; set; }
    }
}