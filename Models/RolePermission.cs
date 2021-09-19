using System;
using System.Collections.Generic;

#nullable disable

namespace MiraiSystem.Models
{
    public partial class RolePermission
    {
        public string RoleId { get; set; }
        public string PermissionId { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public string Id { get; set; }

        public virtual User Creator { get; set; }
        public virtual Permission Permission { get; set; }
        public virtual Role Role { get; set; }
        public virtual User Editor { get; set; }
    }
}
