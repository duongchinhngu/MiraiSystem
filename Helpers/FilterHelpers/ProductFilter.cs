using Microsoft.AspNetCore.Mvc;
using MiraiSystem.Helpers.PagingHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiraiSystem.Helpers.FilterHelpers
{
    public class ProductFilter : QueryStringParameters
    {
        public override string SortBy { get; set; } = "price";
        [FromQuery(Name = "s")]
        public string Search { get; set; } = "";
    }
}
