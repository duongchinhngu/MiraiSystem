using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiraiSystem.Dtos.BaseDtos
{
    public class UserBaseDto
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }
        public string RoleId { get; set; }
        public string Phone { get; set; }
        public string ProfileUrl { get; set; }
        public DateTime Birthdate { get; set; }
        public string Gender { get; set; }
        public DateTime RegisteredAt { get; set; }
    }
}
