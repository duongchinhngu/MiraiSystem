using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiraiSystem.Dtos.BaseDtos
{
    abstract public class FashionProductDto : ProductDto
    {
        public string Colorway { get; set; }
        public string Material { get; set; }
        public string Gender { get; set; }
        public DateTime ReleasedDate { get; set; }
    }
}
