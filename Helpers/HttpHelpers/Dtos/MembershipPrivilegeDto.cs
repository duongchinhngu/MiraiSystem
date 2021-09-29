using System;
using System.Collections.Generic;

#nullable disable

namespace MiraiSystem.Dtos
{
    public partial class MembershipPrivilegeDto
    {
        public string MembershipId { get; set; }
        public string PrivilegeId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public string Id { get; set; }
    }
}
