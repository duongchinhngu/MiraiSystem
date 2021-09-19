using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiraiSystem.Helpers.FilterHelpers
{
    public class FashionProductFilter : ProductFilter
    {
        [FromQuery(Name = "gender")]
        public string Gender { get; set; } = "all";
    }
}
