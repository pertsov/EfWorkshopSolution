using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyApp.Domain.Entities
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool IsActive { get; set; }

        // Relationships
        public IList<Order> Orders { get; set; }

        public Customer()
        {
            Orders = new List<Order>();
        }
    }
}
