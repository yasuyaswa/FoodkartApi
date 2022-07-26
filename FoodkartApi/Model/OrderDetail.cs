using System;
using System.Collections.Generic;

namespace FoodkartApi.Model
{
    public partial class OrderDetail
    {
        public int? ItemId { get; set; }
        public int Sno { get; set; }
        public int? ItemQty { get; set; }
        public int? Amount { get; set; }
        public int? OrderId { get; set; }

        public virtual Menu? Item { get; set; }
    }
}
