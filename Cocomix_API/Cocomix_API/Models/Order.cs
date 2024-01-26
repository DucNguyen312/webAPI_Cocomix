using System;
using System.Collections.Generic;

namespace Cocomix_API.Models
{
    public partial class Order
    {
        public Order()
        {
            CustomerOrders = new HashSet<CustomerOrder>();
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int OrderId { get; set; }
        public string? Note { get; set; }
        public string? Status { get; set; }
        public decimal? TotalPrice { get; set; }
        public int? TotalProduct { get; set; }
        public DateTime? OrderDate { get; set; }
        public int? UserId { get; set; }

        public virtual User? User { get; set; }
        public virtual ICollection<CustomerOrder> CustomerOrders { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
