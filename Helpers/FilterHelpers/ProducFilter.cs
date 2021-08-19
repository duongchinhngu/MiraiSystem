using Microsoft.AspNetCore.Mvc;
using MiraiSystem.Helpers.PagingHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiraiSystem.Helpers.FilterHelpers
{
    public class ProducFilter : QueryStringParameters
    {
        [FromQuery(Name = "order-by")]
        public String OrderBy { get; set; } = "price";
        [FromQuery(Name = "sort-by")]
        public String SortBy { get; set; } = "asc";
    }
}
