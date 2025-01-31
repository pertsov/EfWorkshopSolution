using CompanyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyApp.Domain.Entities
{
    public class Order
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public decimal TotalAmount { get; set; }

        // Navigation properties
        public Customer Customer { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; } // Assuming you may have an OrderItem entity

        public Order()
        {
            OrderItems = new List<OrderItem>();
        }
    }
}
