using MiraiSystem.Helpers.PagingHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiraiSystem.Helpers.FilterHelpers
{
    public interface IFilterHelper<T> where T : class
    {
        void ApplyFilter(ref IQueryable<T> entities);
        void ApplySort(ref IQueryable<T> entities);
        void ApplySearch(ref IQueryable<T> entities);
        PagedList<T> ApplyPaging(IQueryable<T> entities);
    }
}
