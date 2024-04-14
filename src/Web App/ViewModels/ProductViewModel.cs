using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Web_App.Extensions;
using Web_App.Models;

namespace Web_App.ViewModels
{
    public class ProductViewModel
    {
        [Key]
        public Guid Id { get; set; } // Foreign Key

        [Required(ErrorMessage = "{0} field is required")]
        [DisplayName("Supplier")]
        public Guid SupplierId { get; set; }

        [Required(ErrorMessage = "{0} field is required")]
        [StringLength(150, ErrorMessage = "{0} field must be {2} - {1} characters", MinimumLength = 3)]
        public string Name { get; set; }

        [DisplayName("Product description")]
        [Required(ErrorMessage = "{0} field is required")]
        [StringLength(500, ErrorMessage = "{0} field must be {2} - {1} characters", MinimumLength = 3)]
        public string Description { get; set; }

        [Coin]
        [Required(ErrorMessage = "{0} field is required")]
        public decimal Value { get; set; }

        [ScaffoldColumn(false)]
        public DateTime RegisterDate { get; set; }

        [DisplayName("Active?")]
        public bool Active { get; set; }

        public Supplier Supplier { get; set; } // 1 x 1

        public IEnumerable<SupplierViewModel> Suppliers { get; set; }
    }
}
