using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Web_App.ViewModels
{
    public class AddressViewModel
    {
        [Key]
        public Guid Id { get; set; } // Foreign Key


        [Required(ErrorMessage = "{0} field is required")]
        [StringLength(100, ErrorMessage = "{0} field must be {2} - {1} characters", MinimumLength = 10)]
        public string Patio { get; set; }


        [Required(ErrorMessage = "{0} field is required")]
        [StringLength(10, ErrorMessage = "{0} field must be {2} - {1} characters", MinimumLength = 1)]
        public string Number { get; set; }


        public string Complement { get; set; }


        [Required(ErrorMessage = "{0} field is required")]
        [StringLength(8, ErrorMessage = "{0} field must be {2} - {1} characters", MinimumLength = 8)]
        public string ZipCode { get; set; }


        [Required(ErrorMessage = "{0} field is required")]
        [StringLength(30, ErrorMessage = "{0} field must be {2} - {1} characters", MinimumLength = 3)]
        public string Neighborhood { get; set; }


        [Required(ErrorMessage = "{0} field is required")]
        [StringLength(30, ErrorMessage = "{0} field must be {2} - {1} characters", MinimumLength = 2)]
        public string City { get; set; }


        [Required(ErrorMessage = "{0} field is required")]
        [StringLength(30, ErrorMessage = "{0} field must be {2} - {1} characters", MinimumLength = 2)] // Complete name or acronym
        public string State { get; set; }


        [HiddenInput]
        public Guid SupplierId { get; set; }
    }
}