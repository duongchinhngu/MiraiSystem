using System;
using System.Collections.Generic;

#nullable disable

namespace MiraiSystem.Models
{
    public partial class ProductImage
    {
        public string ImageId { get; set; }
        public string Url { get; set; }
        public string Sku { get; set; }
        public string ImageRole { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }

        public virtual User Creator { get; set; }
        public virtual Shoes Shoes { get; set; }
        public virtual User Editor { get; set; }

        public static readonly string THUMPNAIL_IMAGE = "Thumpnail"; 
        public static readonly string DETAIL_IMAGE = "Detail Image"; 
    }
}
