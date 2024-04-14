using System.Collections;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Web_App.ViewModels
{
    public class SupplierViewModel : IEnumerable
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "{0} field is required")]
        [StringLength(100, ErrorMessage = "{0} field must be {2} - {1} characters", MinimumLength = 2)]
        public string Name { get; set; }

        [Required(ErrorMessage = "{0} field is required")]
        [StringLength(14, ErrorMessage = "{0} field must be {2} - {1} characters", MinimumLength = 11)] // CPF or CPNJ
        public string Document { get; set; }

        [DisplayName("Type")]
        public int SupplierType { get; set; }

        public  AddressViewModel Address { get; set; }

        [DisplayName("Active?")]
        public bool Active { get; set; }

        public IEnumerable<ProductViewModel> Products { get; set; } // 1 x N
        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
