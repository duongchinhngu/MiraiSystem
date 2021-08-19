using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiraiSystem.Dtos.BaseDtos
{
    public class ImageBaseDto
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Status { get; set; }
        public string Purpose { get; set; }

    }
}
