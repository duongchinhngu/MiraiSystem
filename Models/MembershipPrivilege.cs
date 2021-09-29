using System;
using System.Collections.Generic;

#nullable disable

namespace MiraiSystem.Models
{
    public partial class MembershipPrivilege
    {
        public string MembershipId { get; set; }
        public string PrivilegeId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public string Id { get; set; }

        public virtual User Creator { get; set; }
        public virtual Membership Membership { get; set; }
        public virtual Privilege Privilege { get; set; }
        public virtual User Editor { get; set; }
    }
}
