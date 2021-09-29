using Microsoft.AspNetCore.Mvc;
using MiraiSystem.Helpers.FilterHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiraiSystem.Helpers.SortHelpers
{
    public class SortParameters
    {
        public static readonly string ASCENDING_SORT = "asc";
        public static readonly string DESCENDING_SORT = "desc";
        public static readonly string DEFAULT_SORT = "default";
    }
}
