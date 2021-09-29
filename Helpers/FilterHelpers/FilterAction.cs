using MiraiSystem.Helpers.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Reflection;
using System.Threading.Tasks;

namespace MiraiSystem.Helpers.FilterHelpers
{
    public partial class FilterAction<T> where T : class
    {
        public static void ApplyFilter(ref IQueryable<T> entities, GenericFilter filter)
        {
            if (entities == null || !entities.Any())
            {
                return;
            }

            PropertyInfo[] properties = GetFilterProperties(filter);

            foreach (var p in properties)
            {
                var attributeValue = filter.GetType().GetProperty(p.Name).GetValue(filter, null);

                if (!Utils.Utils.IsNullOrDefaultValue(attributeValue))
                {
                    entities = entities.Where($"{p.Name} = @0", attributeValue);
                }
            }
        }

        private static PropertyInfo[] GetFilterProperties(GenericFilter filter)
        {
            PropertyInfo[] properties = GetMathedProperties(filter, typeof(T));
            return properties;
        }

        private static PropertyInfo[] GetMathedProperties(GenericFilter filter, Type typeParameter)
        {
            PropertyInfo[] properties = filter.GetType().GetProperties();
            PropertyInfo[] queryStringParameterProperties = typeParameter.GetProperties();
            properties = properties.Where(p => queryStringParameterProperties.Any(g => g.Name.Equals(p.Name))).ToArray();
            return properties;
        }
    }
}
