using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiraiSystem.Helpers.SortHelpers
{
    public interface ISortHelper<T> where T : class
    {
        public void ApplySort(ref IQueryable<T> entities);
    }
}
