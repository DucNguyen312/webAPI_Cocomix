using System;
using System.Collections.Generic;

namespace Cocomix_API.Models
{
    public partial class CustomerOrder
    {
        public int Id { get; set; }
        public int? CustomerId { get; set; }
        public int? OrderId { get; set; }

        public virtual Customer? Customer { get; set; }
        public virtual Order? Order { get; set; }
    }
}
