using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Sakamoto.TCC2.CSU.Patient.Application.ViewModels
{
    public class AddressViewModel
    {
        [Required(ErrorMessage = "City name is required")]
        [MinLength(2)]
        [MaxLength(100)]
        public string City { get; set; }

        [Required(ErrorMessage = "District is required")]
        [MinLength(2)]
        [MaxLength(255)]
        public string District { get; set; }

        [Required(ErrorMessage = "Number is required")]
        [MinLength(2)]
        [MaxLength(10)]
        public string Number { get; set; }

        [MaxLength(255)] public string Observation { get; set; }

        [Required(ErrorMessage = "Postal code is required")]
        [DisplayName("Postal Code")]
        [MaxLength(8)]
        public string PostalCode { get; set; }

        [Required(ErrorMessage = "District is required")]
        [StringLength(2)]
        public string State { get; set; }

        [Required(ErrorMessage = "Street name is required")]
        [MaxLength(255)]
        public string Street { get; set; }
    }
}