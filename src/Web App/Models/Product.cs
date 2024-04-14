using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web_App.Models
{
    public class Product : Entity
    {
        public Guid SupplierId { get; set; } // Foreign Key

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Value { get; set; }

        public DateTime RegisterDate { get; set; }

        public bool Active { get; set; }


        /* EF Relation */
        public Supplier Supplier { get; set; } // 1 x 1
    }
}
