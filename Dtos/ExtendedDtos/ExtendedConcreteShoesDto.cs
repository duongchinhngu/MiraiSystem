using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiraiSystem.Dtos.ExtendedDtos
{
    public class ExtendedConcreteShoesDto : ConcreteShoesDto
    {
        public string ShoesName { get; set; }
        public string MainImageUrl { get; set; }
    }
}
