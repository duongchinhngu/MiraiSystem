using MiraiSystem.Dtos.BaseDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiraiSystem.Dtos
{
    public class ShoesDto : ProductDto
    {
        public string Colorway { get; set; }
        public DateTime ReleasedDate { get; set; }
       
    }
}
