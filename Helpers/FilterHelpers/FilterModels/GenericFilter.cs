
using Microsoft.AspNetCore.Mvc;
using MiraiSystem.Helpers.PagingHelpers;
using MiraiSystem.Helpers.Parameters;
using MiraiSystem.Helpers.SortHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace MiraiSystem.Helpers.FilterHelpers
{
    public class GenericFilter : QueryStringParameters
    {
        [FromQuery(Name = "q")]
        public string Search { get; set; } = "";
        public override string SortBy { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
