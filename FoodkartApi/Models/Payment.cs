using System;
using System.Collections.Generic;

namespace FoodkartApi.Models
{
    public partial class Payment
    {
        public int PaymentId { get; set; }
        public int? TotalAmount { get; set; }
        public string? PaymentMode { get; set; }
        public int? CustomerId { get; set; }

        public virtual Customer? Customer { get; set; }
    }
}
