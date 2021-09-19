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
        public string Status { get; set; }
        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "SubTotal must be a positive double number.")]
        public double SubTotal { get; set; }
        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Total must be a positive double number.")]
        public double Total { get; set; }
    }
}
