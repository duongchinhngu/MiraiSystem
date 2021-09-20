using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiraiSystem.Dtos.BaseDtos
{
    abstract public class FashionProductDto : ProductDto
    {
        [FromQuery(Name = "colorway")]
        public string Colorway { get; set; }

        [FromQuery(Name = "material")]
        public string Material { get; set; }

        [FromQuery(Name = "gender")]
        public string Gender { get; set; }

        [FromQuery(Name = "released-date")]
        public DateTime ReleasedDate { get; set; }
    }
}
