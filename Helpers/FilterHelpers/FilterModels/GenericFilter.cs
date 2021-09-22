using Microsoft.AspNetCore.Mvc;
using MiraiSystem.Helpers.PagingHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace MiraiSystem.Helpers.FilterHelpers
{
    public abstract class GenericFilter : QueryStringParameters
    {
        public override string SortBy { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public PropertyInfo[] GetFilterProperties()
        {
            var generalProperties = typeof(QueryStringParameters).GetProperties();
            var properties = this.GetType().GetProperties();
            properties = properties.Where(p => !generalProperties.Any(g => g.Name.Equals(p.Name))).ToArray();
            return properties;
        }

    }
}
