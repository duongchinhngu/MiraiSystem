using MiraiSystem.Helpers.FilterHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;

namespace MiraiSystem.Helpers.SortHelpers
{
    public class SortHelper<T> where T : class
    {
        public static readonly string ASCENDING_SORT = "asc";
        public static readonly string DESCENDING_SORT = "desc";
        public static readonly string DEFAULT_SORT = "default";
        public static IQueryable<T> ApplySort(IQueryable<T> entities, string orderBy, string sortBy)
        {
            if(!entities.Any())
            {
                return entities;
            }
            if( String.IsNullOrWhiteSpace(orderBy) || String.IsNullOrWhiteSpace(sortBy))
            {
                return entities;
            }

            if (orderBy.Equals(DEFAULT_SORT))
            {
                return entities;
            }

            var propertyInfos = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var sortQueryBuilder = new StringBuilder();

            var objectProperty = propertyInfos.FirstOrDefault(pi => pi.Name.Equals(sortBy, StringComparison.InvariantCultureIgnoreCase));
            var sortingOrder = orderBy.Contains(ASCENDING_SORT)? "ascending" : "descending";
            sortQueryBuilder.Append($"{objectProperty.Name.ToString()} {sortingOrder}");

            return entities.OrderBy(sortQueryBuilder.ToString());
        }

        public static IQueryable<T> ApplyFilter(IQueryable<T> entities, string orderBy, string sortBy)
        {
            if (!entities.Any())
            {
                return entities;
            }
            if (String.IsNullOrWhiteSpace(orderBy) || String.IsNullOrWhiteSpace(sortBy))
            {
                return entities;
            }

            if (orderBy.Equals(DEFAULT_SORT))
            {
                return entities;
            }

            var propertyInfos = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var sortQueryBuilder = new StringBuilder();

            var objectProperty = propertyInfos.FirstOrDefault(pi => pi.Name.Equals(sortBy, StringComparison.InvariantCultureIgnoreCase));
            var sortingOrder = orderBy.Contains(ASCENDING_SORT) ? "ascending" : "descending";
            sortQueryBuilder.Append($"{objectProperty.Name.ToString()} {sortingOrder}");

            return entities.OrderBy(sortQueryBuilder.ToString());
        }
    }
}
