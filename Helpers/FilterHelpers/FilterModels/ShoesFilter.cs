using Microsoft.AspNetCore.Mvc;
using MiraiSystem.Helpers.PagingHelpers;
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
    public class ShoesFilter : FashionProductFilter, IFilterHelper<Shoes>
    {
        [FromQuery(Name = "size")]
        public decimal Size { get; set; }

        [FromQuery(Name = "is-load-all")]
        public bool IsLoadAll { get; set; } = default;

        public void ApplyFilter(ref IQueryable<Shoes> entities)
        {
            FilterAction<Shoes>.ApplyFilter(ref entities, this);
        }

        public PagedList<Shoes> ApplyPaging(IQueryable<Shoes> entities)
        {
            return PagedList<Shoes>.ToPagedList(entities, this.PageNumber, this.PageSize);
        }

        public void ApplySearch(ref IQueryable<Shoes> entities)
        {
            entities = entities.Where(s => s.Name.Contains(this.Search));
        }

        public void ApplySort(ref IQueryable<Shoes> entities)
        {
            FilterAction<Shoes>.ApplySort(ref entities, this.OrderBy, this.SortBy);
        }
    }
}
