using System;
using System.Collections.Generic;

namespace FoodkartApi.Models
{
    public partial class Admin
    {
        public string UserId { get; set; } = null!;
        public string? AdminPass { get; set; }
        public string? AdminEmail { get; set; }
        public decimal? AdminMobile { get; set; }
        public byte[]? AdminPasswordHash { get; set; }
        public byte[]? AdminPasswordSalt { get; set; }
    }
}
