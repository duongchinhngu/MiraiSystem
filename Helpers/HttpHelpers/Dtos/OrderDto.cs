using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MiraiSystem.Dtos
{
    public class OrderDto
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required(ErrorMessage = "UserId is required")]
        [StringLength(64, ErrorMessage = "UserId can't be longer than 64 characters")]
        public string UserId { get; set; }

        public DateTime CreatedAt { get; set; }

        [Required(ErrorMessage = "Status is required")]
        [StringLength(20, ErrorMessage = "Status can't be longer than 20 characters")]
        public string Status { get; set; }

        [Required(ErrorMessage = "Subtotal is required")]
        [Range(0, double.MaxValue, ErrorMessage = "SubTotal must be a positive double number.")]
        public double SubTotal { get; set; }

        [Required(ErrorMessage = "Total is required")]
        [Range(0, double.MaxValue, ErrorMessage = "Total must be a positive double number.")]
        public double Total { get; set; }

        [Required(ErrorMessage = "Grand total is required")]
        [Range(0, double.MaxValue, ErrorMessage = "GrandTotal must be a positive double number.")]
        public double GrandTotal { get; set; }

        [StringLength(64, ErrorMessage = "PromotionID can't be longer than 64 characters")]
        public string PromotionID { get; set; }

        [Required(ErrorMessage = "ShippingAdressID is required")]
        [StringLength(64, ErrorMessage = "ShippingAdressID can't be longer than 64 characters")]
        public string ShippingAdressID { get; set; }

    }
}
