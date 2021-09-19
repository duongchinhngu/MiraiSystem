using System;
using System.Collections.Generic;

#nullable disable

namespace MiraiSystem.Models
{
    public partial class Permission
    {
        public Permission()
        {
            RolePermissions = new HashSet<RolePermission>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }

        public virtual User Creator { get; set; }
        public virtual User Editor { get; set; }
        public virtual ICollection<RolePermission> RolePermissions { get; set; }
    }
}
