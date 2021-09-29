using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MiraiSystem.Dtos
{
    public class OrderItemDto
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [Required(ErrorMessage = "Sku is required")]
        [StringLength(64, ErrorMessage = "Sku can't be longer than 64 characters")]
        public string Sku { get; set; }
        public string OrderId { get; set; }
        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Price must be a positive double number.")]
        public double Price { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Order Item quantity must be a positive integer number greater than 1.")]
        public int Quantity { get; set; }
        public DateTime UpdatedAt { get; set; }
        [Required(ErrorMessage = "UpdatedBy is an userId and required")]
        [StringLength(64, ErrorMessage = "UpdatedBy can't be longer than 64 characters")]
        public string UpdatedBy { get; set; }
    }
}
