using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiraiSystem.Helpers.PagingHelpers
{
    public abstract class QueryStringParameters
    {
        const int maxPageSize = 50;
        [FromQuery(Name ="page-numer")]
        public int PageNumber { get; set; } = 1;

        private int _pageSize = 10;
        [FromQuery(Name = "page-size")]
        public int PageSize
        {
            get { return _pageSize; }
            set { _pageSize = (value < maxPageSize) ? value : maxPageSize; }
        }
    }
}
