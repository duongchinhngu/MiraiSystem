using System;
using System.Collections.Generic;

#nullable disable

namespace MiraiSystem.Models
{
    public partial class Country
    {
        public Country()
        {
            Cities = new HashSet<City>();
        }

        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string DialCode { get; set; }

        public virtual ICollection<City> Cities { get; set; }
    }
}
