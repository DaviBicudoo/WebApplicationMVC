namespace Web_App.Models
{
    public class Address : Entity
    {
        public Guid SupplierId { get; set; } // Foreign Key

        public string Patio { get; set; }

        public string Number { get; set; }

        public string Complement { get; set; }

        public string ZipCode { get; set; }

        public string Neighborhood { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        /* EF Relation */
        public Supplier Supplier { get; set; } // 1 x 1
    }
}