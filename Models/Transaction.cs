using System;
using System.Collections.Generic;

#nullable disable

namespace MiraiSystem.Models
{
    public partial class Transaction
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string OrderId { get; set; }
        public string CreatedAt { get; set; }
    }
}
