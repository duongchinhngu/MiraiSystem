using System;
using System.Collections.Generic;

#nullable disable

namespace MiraiSystem.Models
{
    public partial class District
    {
        public District()
        {
            Addresses = new HashSet<Address>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string CityId { get; set; }

        public virtual City City { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
    }
}
