using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiraiSystem.Models.BaseModels
{
    public class UserBase
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }

    }
}
