using System;
using System.Collections.Generic;

namespace Cocomix_API.Models
{
    public partial class Customer
    {
        public Customer()
        {
            CustomerOrders = new HashSet<CustomerOrder>();
        }

        public int CustomerId { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }

        public virtual ICollection<CustomerOrder> CustomerOrders { get; set; }
    }
}
