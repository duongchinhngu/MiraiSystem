using Microsoft.AspNetCore.Mvc;
using MiraiSystem.Helpers.PagingHelpers;
using MiraiSystem.Helpers.SortHelpers;
using MiraiSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Reflection;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace MiraiSystem.Helpers.FilterHelpers
{
    public class ShoesFilter : FashionProductFilter, IFilterHelper<Shoes>, ISortHelper<Shoes>
    {

        [FromQuery(Name = "size")]
        public decimal Size { get; set; }

        public void ApplyFilter(ref IQueryable<Shoes> entities)
        {
            FilterHelper<Shoes>.ApplyFilter(ref entities, this);
        }

        public void ApplySort(ref IQueryable<Shoes> entities)
        {
            SortHelper<Shoes>.ApplySort(ref entities, this.OrderBy, this.SortBy);
        }
    }
}
