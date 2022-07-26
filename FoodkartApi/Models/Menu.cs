using System;
using System.Collections.Generic;

namespace FoodkartApi.Models
{
    public partial class Menu
    {
        public Menu()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int ItemId { get; set; }
        public string ItemName { get; set; } = null!;
        public int ItemPrice { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
