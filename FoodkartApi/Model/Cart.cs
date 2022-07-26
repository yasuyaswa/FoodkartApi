using System;
using System.Collections.Generic;

namespace FoodkartApi.Model
{
    public partial class Cart
    {
        public decimal ItemId { get; set; }
        public string ItemName { get; set; } = null!;
        public decimal ItemPrice { get; set; }
    }
}
