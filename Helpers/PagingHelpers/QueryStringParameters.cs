using Microsoft.AspNetCore.Mvc;
using MiraiSystem.Helpers.FilterHelpers;
using MiraiSystem.Helpers.SortHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiraiSystem.Helpers.PagingHelpers
{
    public abstract class QueryStringParameters
    {
        const int maxPageSize = 50;
        [FromQuery(Name ="page-number")]
        public int PageNumber { get; set; } = 1;

        private int _pageSize = 10;
        [FromQuery(Name = "page-size")]
        public int PageSize
        {
            get { return _pageSize; }
            set { _pageSize = (value < maxPageSize) ? value : maxPageSize; }
        }
        //for sorting
        [FromQuery(Name = "order-by")]
        public String OrderBy { get; set; } = SortHelper<object>.DEFAULT_SORT;
        [FromQuery(Name = "sort-by")]
        public abstract String SortBy { get; set; }
    }
}
