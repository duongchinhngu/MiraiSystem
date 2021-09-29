using Microsoft.AspNetCore.Mvc;
using MiraiSystem.Helpers.PagingHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiraiSystem.Helpers.FilterHelpers
{
    public class ProductFilter : GenericFilter
    {
        public override string SortBy { get; set; } = "price";

        [FromQuery(Name = "model-code")]
        public string ModelCode { get; set; }

        [FromQuery(Name = "status")]
        public string Status { get; set; }
    }
}
