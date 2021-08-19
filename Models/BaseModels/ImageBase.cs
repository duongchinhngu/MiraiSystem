using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiraiSystem.Models.BaseModels
{
    public class ImageBase
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Status { get; set; }
        public string Purpose { get; set; }
        
    }
}
