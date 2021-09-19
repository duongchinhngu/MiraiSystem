using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiraiSystem.Dtos.BaseDtos
{
    public abstract class ProductDto
    {
        public string Sku { get; set; } = Guid.NewGuid().ToString();
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
    }
}
