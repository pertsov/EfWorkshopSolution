using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyApp.Domain.Entities
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public bool IsActive { get; set; }

        // Optional: You might want to include navigation properties for related data
        // public ICollection<OrderItem> OrderItems { get; set; }

        public Product()
        {
            // Initialize collections to prevent null reference exceptions
            // OrderItems = new List<OrderItem>();
        }
    }
}
