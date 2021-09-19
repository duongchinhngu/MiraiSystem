using System;
using System.Collections.Generic;

#nullable disable

namespace MiraiSystem.Models
{
    public partial class OrderItem
    {
        public string Id { get; set; }
        public string Sku { get; set; }
        public string OrderId { get; set; }
        public double Price { get; set; }
        public UInt16 Quantity { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public virtual Order Order { get; set; }
        public virtual Shoes Shoes { get; set; }
        public virtual User Editor { get; set; }
    }
}
