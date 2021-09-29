using Microsoft.AspNetCore.Mvc;
using MiraiSystem.Helpers.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MiraiSystem.Dtos.BaseDtos
{
    public abstract class ProductDto
    {
        [FromQuery(Name = "sku")]
        public string Sku { get; set; } = Guid.NewGuid().ToString();

        [FromQuery(Name = "name")]
        [Required(ErrorMessage = "Name is required")]
        [StringLength(64, ErrorMessage = "Product name can't be longer than 64 characters")]
        public string Name { get; set; }

        [FromQuery(Name = "description")]
        [StringLength(2048, ErrorMessage = "Product name can't be longer than 64 characters")]
        public string Description { get; set; }

        [FromQuery(Name = "status")]
        [Required(ErrorMessage = "Status is required")]
        [StringLength(20, ErrorMessage = "Product status can't be longer than 64 characters")]
        public string Status { get; set; }

        [FromQuery(Name = "category-id")]
        [Required]
        [StringLength(64, ErrorMessage = "CategoryId name can't be longer than 64 characters")]
        public string CategoryId { get; set; }

        [FromQuery(Name = "brand-id")]
        [Required(ErrorMessage = "BrandId is required")]
        [StringLength(64, ErrorMessage = "BrandId name can't be longer than 64 characters")]
        public string BrandId { get; set; }

        [FromQuery(Name = "price")]
        [Required(ErrorMessage = "Price is required")]
        [Range(0, double.MaxValue, ErrorMessage = "Price must be a positive double number.")]
        public double Price { get; set; }

        [Required(ErrorMessage = "Quantity is required")]
        [Range(0, int.MaxValue, ErrorMessage = "Quantity must be a positive int number.")]
        [FromQuery(Name = "quantity")]
        public int Quantity { get; set; }

        [FromQuery(Name = "model-code")]
        [Required(ErrorMessage = "ModelCode is required")]
        [StringLength(64, ErrorMessage = "ModelCode name can't be longer than 64 characters")]
        public string ModelCode { get; set; }

        [FromQuery(Name = "created-at")]
        public DateTime CreatedAt { get; set; } = Utils.GetDateTimeUTCNow();

        [FromQuery(Name = "updated-at")]
        public DateTime UpdatedAt { get; set; } = Utils.GetDateTimeUTCNow();

        [FromQuery(Name = "created-by")]
        [Required(ErrorMessage = "CreatedBy is required")]
        [StringLength(64, ErrorMessage = "CreatedBy is an userID and can't be longer than 64 characters")]
        public string CreatedBy { get; set; }

        [FromQuery(Name = "updated-by")]
        [Required(ErrorMessage = "UpdatedBy is required")]
        [StringLength(64, ErrorMessage = "UpdatedBy is an userID and can't be longer than 64 characters")]
        public string UpdatedBy { get; set; }

        [FromQuery(Name = "discount")]
        [Range(0, 1.0, ErrorMessage = "Discount ratio must be from 0 to 1.0.")]
        public decimal Discount { get; set; }
    }
}
