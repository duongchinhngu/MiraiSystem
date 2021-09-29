using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MiraiSystem.Dtos
{
    public class TransactionDto
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [Required(ErrorMessage = "UserId is required")]
        [StringLength(64, ErrorMessage = "UserId can't be longer than 64 characters")]
        public string UserId { get; set; }
        public string OrderId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string Description { get; set; }

        [Required(ErrorMessage = "Status is required")]
        [StringLength(20, ErrorMessage = "Status can't be longer than 20 characters")]
        public string Status { get; set; }
        [Required(ErrorMessage = "Type is required")]
        [StringLength(20, ErrorMessage = "Type can't be longer than 20 characters")]
        public string Type { get; set; }
        [Required(ErrorMessage = "Mode is required")]
        [StringLength(20, ErrorMessage = "Mode can't be longer than 20 characters")]
        public string Mode { get; set; }
    }
}
