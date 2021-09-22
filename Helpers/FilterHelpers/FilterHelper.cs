using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Reflection;
using System.Threading.Tasks;

namespace MiraiSystem.Helpers.FilterHelpers
{
    public class FilterHelper<T> where T : class
    {
        public static void ApplyFilter(ref IQueryable<T> entities, GenericFilter filter)
        {
            if (entities == null || !entities.Any())
            {
                return;
            }

            PropertyInfo[] properties = filter.GetFilterProperties();

            foreach (var p in properties)
            {
                var attributeValue = filter.GetType().GetProperty(p.Name).GetValue(filter, null);

                if (!Utils.Utils.IsNullOrDefaultValue(attributeValue))
                {

                    entities = entities.Where($"{p.Name} = @0", attributeValue);
                    Console.WriteLine("this is not null: " + p.Name + " -- " + attributeValue + "----" + p.PropertyType.Equals(typeof(string)));
                }
            }
        }
    }
}
