using System;
using System.Collections.Generic;

#nullable disable

namespace MiraiSystem.Models
{
    public partial class Membership
    {
        public Membership()
        {
            MembershipPrivileges = new HashSet<MembershipPrivilege>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public decimal PointRate { get; set; }
        public int PointTarget { get; set; }

        public virtual User Creator { get; set; }
        public virtual User Editor { get; set; }
        public virtual ICollection<MembershipPrivilege> MembershipPrivileges { get; set; }
    }
}
