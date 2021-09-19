using MiraiSystem.Dtos.BaseDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiraiSystem.Dtos
{
    public class ProductImageDto : ImageBaseDto
    {
        public string Sku { get; set; }
    }
}
