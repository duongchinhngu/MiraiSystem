using Microsoft.AspNetCore.Mvc;
using MiraiSystem.Helpers.FilterHelpers;
using MiraiSystem.Helpers.PagingHelpers;
using MiraiSystem.Helpers.SortHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiraiSystem.Helpers.Parameters
{
    public abstract class QueryStringParameters
    {
        [FromQuery(Name = "page-number")]
        public int PageNumber { get; set; } = 1;

        private int _pageSize = PagingParameters.DEFAULT_PAGESIZE;
        [FromQuery(Name = "page-size")]
        public int PageSize
        {
            get { return _pageSize; }
            set { _pageSize = (value < PagingParameters.MAX_PAGESIZE) ? value : PagingParameters.MAX_PAGESIZE; }
        }

        //for sorting
        [FromQuery(Name = "order-by")]
        public String OrderBy { get; set; } = SortParameters.DEFAULT_SORT;

        [FromQuery(Name = "sort-by")]
        public abstract String SortBy { get; set; }
    }
}
