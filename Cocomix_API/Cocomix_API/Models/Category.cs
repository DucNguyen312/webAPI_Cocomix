using System;
using System.Collections.Generic;

namespace Cocomix_API.Models
{
    public partial class Category
    {
        public Category()
        {
            ProductCategories = new HashSet<ProductCategory>();
        }

        public int CategoryId { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<ProductCategory> ProductCategories { get; set; }
    }
}
