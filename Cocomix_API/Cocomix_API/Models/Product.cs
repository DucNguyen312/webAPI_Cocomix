using System;
using System.Collections.Generic;

namespace Cocomix_API.Models
{
    public partial class Product
    {
        public Product()
        {
            OrderDetails = new HashSet<OrderDetail>();
            ProductCategories = new HashSet<ProductCategory>();
        }

        public int ProductId { get; set; }
        public string? Name { get; set; }
        public decimal? Price { get; set; }
        public int? Quantity { get; set; }
        public string? Note { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual ICollection<ProductCategory> ProductCategories { get; set; }
    }
}
