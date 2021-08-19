using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace MiraiSystem.Helpers.FilterHelpers
{
    public class ShoesFilter : ProducFilter
    {
        [FromQuery(Name = "gender")]
        public string Gender { get; set; } = "women";
        [FromQuery(Name = "size")]
        public double Size { get; set; } = 10.0;
    }
}
