using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiraiSystem.Dtos.BaseDtos
{
    public abstract class ProductDto
    {
        [FromQuery(Name = "sku")]
        public string Sku { get; set; } = Guid.NewGuid().ToString();

        [FromQuery(Name = "name")]
        public string Name { get; set; }

        [FromQuery(Name = "description")]
        public string Description { get; set; }

        [FromQuery(Name = "status")]
        public string Status { get; set; }

        [FromQuery(Name = "category-id")]
        public string CategoryId { get; set; }

        [FromQuery(Name = "brand-id")]
        public string BrandId { get; set; }

        [FromQuery(Name = "price")]
        public double Price { get; set; }

        [FromQuery(Name = "quantity")]
        public decimal Quantity { get; set; }

        [FromQuery(Name = "model-code")]
        public string ModelCode { get; set; }

        [FromQuery(Name = "created-at")]
        public DateTime CreatedAt { get; set; }

        [FromQuery(Name = "updated-at")]
        public DateTime UpdatedAt { get; set; }

        [FromQuery(Name = "created-by")]
        public string CreatedBy { get; set; }

        [FromQuery(Name = "updated-by")]
        public string UpdatedBy { get; set; }
    }
}
