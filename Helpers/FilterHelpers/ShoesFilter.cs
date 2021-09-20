using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace MiraiSystem.Helpers.FilterHelpers
{
    public class ShoesFilter : FashionProductFilter
    {

        [FromQuery(Name = "size")]
        public decimal Size { get; set; } = 0.0m;

    }
}
