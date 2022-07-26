using System;
using System.Collections.Generic;

namespace FoodkartApi.Models
{
    public partial class Order
    {
        public int OrderId { get; set; }
        public DateTime? OrderDate { get; set; }
        public int? OrderTotal { get; set; }
        public string? OrderStatus { get; set; }
        public int? CustomerId { get; set; }

        public virtual Customer? Customer { get; set; }
    }
}
