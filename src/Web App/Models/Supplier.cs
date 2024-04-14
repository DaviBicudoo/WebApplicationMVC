using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Web_App.Models;

namespace Web_App.Models
{
    public class Supplier : Entity
    {
        public string Name { get; set; }

        public string Document { get; set; } // CPF or CNPJ

        public SupplierType SupplierType { get; set; }

        public Address Address { get; set; }

        public bool Active { get; set; }


        /* EF Relation */
        public IEnumerable<Product> Products { get; set; } // 1 x N
    }
}
