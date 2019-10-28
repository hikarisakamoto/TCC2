using System;
using System.ComponentModel.DataAnnotations;

namespace Sakamoto.TCC2.CSU.Patient.Application.ViewModels
{
    public class UpdatePatientHeartRateViewModel
    {
        [Required(ErrorMessage = "Heart rate is required")]
        public int HeartRate { get; set; }

        [Key] public Guid Id { get; set; }
    }
}