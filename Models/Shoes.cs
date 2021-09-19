using System;
using System.Collections.Generic;

#nullable disable

namespace MiraiSystem.Models
{
    public partial class Shoes : FashionProduct
    {
        public decimal Size { get; set; }

        public override Brand Brand { get => base.Brand; set => base.Brand = value; }
        public override Category Category { get => base.Category; set => base.Category = value; }
        public override User Creator { get => base.Creator; set => base.Creator = value; }
        public override User Editor { get => base.Editor; set => base.Editor = value; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
        public virtual ICollection<ProductImage> ProductImages { get; set; }

        public Shoes GetShoes(ICollection<ProductImage> productImages)
        {
            return new Shoes
            {
                ModelCode = this.ModelCode,
                Material = this.Material,
                Gender = this.Gender,
                BrandId = this.BrandId,
                Name = this.Name,
                CategoryId = this.CategoryId,
                Colorway = this.Colorway,
                CreatedAt = this.CreatedAt,
                CreatedBy = this.CreatedBy,
                Description = this.Description,
                Price = this.Price,
                Quantity = this.Quantity,
                ReleasedDate = this.ReleasedDate,
                Size = this.Size,
                Sku = this.Sku,
                Status = this.Status,
                UpdatedAt = this.UpdatedAt,
                UpdatedBy = this.UpdatedBy,
                ProductImages = productImages
            };
        }

        public bool IsAvailable()
        {
            return this.Quantity > 0 && this.Status.Equals(INSTOCK_STATUS);
        }

    }
}
