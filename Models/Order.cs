using System;
using System.Collections.Generic;

#nullable disable

namespace MiraiSystem.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderItems = new HashSet<OrderItem>();
        }

        public string Id { get; set; }
        public string UserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Status { get; set; }
        public double SubTotal { get; set; }
        public double Total { get; set; }
        public double GrandTotal { get; set; }
        public string PromotionID { get; set; }
        public string ShippingAddressID { get; set; }

        public virtual User User { get; set; }
        public virtual Promotion Promotion { get; set; }
        public virtual Address Address { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }


        public override string ToString()
        {
            return this.Id + "and" + this.UserId;
        }
    }
}
