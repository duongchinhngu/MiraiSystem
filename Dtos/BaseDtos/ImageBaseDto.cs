using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiraiSystem.Dtos.BaseDtos
{
    public class ImageBaseDto
    {
        public string ImageId { get; set; } = Guid.NewGuid().ToString();
        public string Url { get; set; }
        public string Status { get; set; }
        public string ImageRole { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
    }
}
