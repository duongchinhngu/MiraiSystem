using System;
using System.Collections.Generic;

#nullable disable

namespace MiraiSystem.Dtos
{
    public partial class CountryDto
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string DialCode { get; set; }
    }
}
