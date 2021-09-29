using System;
using System.Collections.Generic;

#nullable disable

namespace MiraiSystem.Models
{
    public partial class Address
    {
        public string Id { get; set; }
        public string DistrictId { get; set; }
        public string Detail { get; set; }
        public string UserId { get; set; }

        public virtual District District { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
