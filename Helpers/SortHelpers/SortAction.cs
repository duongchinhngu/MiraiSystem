using MiraiSystem.Helpers.FilterHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
using MiraiSystem.Models;
using System.ComponentModel;
using MiraiSystem.Helpers.PagingHelpers;
using MiraiSystem.Helpers.SortHelpers;

namespace MiraiSystem.Helpers.FilterHelpers
{
    public partial class FilterAction<T> where T : class
    {
        public static void ApplySort(ref IQueryable<T> entities, string orderBy, string sortBy)
        {
            if (!entities.Any())
            {
                return;
            }
            if (String.IsNullOrWhiteSpace(orderBy) || String.IsNullOrWhiteSpace(sortBy))
            {
                return;
            }
            if (orderBy.Equals(SortParameters.DEFAULT_SORT))
            {
                return;
            }

            var propertyInfos = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var sortQueryBuilder = new StringBuilder();

            var objectProperty = propertyInfos.FirstOrDefault(pi => pi.Name.Equals(sortBy, StringComparison.InvariantCultureIgnoreCase));
            var sortingOrder = orderBy.Contains(SortParameters.ASCENDING_SORT) ? "ascending" : "descending";
            sortQueryBuilder.Append($"{objectProperty.Name.ToString()} {sortingOrder}");

            entities = entities.OrderBy(sortQueryBuilder.ToString());
        }
    }
}
