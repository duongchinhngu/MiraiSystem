using Microsoft.AspNetCore.Mvc;
using MiraiSystem.Dtos.BaseDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiraiSystem.Dtos
{
    public class ShoesDto : FashionProductDto
    {
        [FromQuery(Name ="size")]
        public decimal Size { get; set; }

        public ICollection<ProductImageDto> ProductImages { get; set; }
    }
}
