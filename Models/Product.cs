using System;
using System.Collections.Generic;

#nullable disable

namespace MiraiSystem.Models
{
    public abstract partial class Product
    {
        public string Sku { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public string CategoryId { get; set; }
        public string BrandId { get; set; }
        public double Price { get; set; }
        public decimal Quantity { get; set; }
        public string ModelCode { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }

        public virtual Brand Brand { get; set; }
        public virtual Category Category { get; set; }
        public virtual User Creator { get; set; }
        public virtual User Editor { get; set; }

        public static readonly string INSTOCK_STATUS = "InStock";
        public static readonly string OUTSTOCK_STATUS = "OutOfStock";


    }
}
