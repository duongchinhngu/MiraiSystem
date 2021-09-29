using System;
using System.Collections.Generic;

#nullable disable

namespace MiraiSystem.Dtos
{
    public partial class PromotionDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public double Value { get; set; }
        public string UserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime ExpiredAt { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public string Code { get; set; }
    }
}
