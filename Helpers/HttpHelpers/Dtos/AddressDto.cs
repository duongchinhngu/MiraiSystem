using System;
using System.Collections.Generic;

#nullable disable

namespace MiraiSystem.Dtos
{
    public partial class AddressDto
    {
        public string Id { get; set; }
        public string DistrictId { get; set; }
        public string Detail { get; set; }
        public string UserId { get; set; }
    }
}
