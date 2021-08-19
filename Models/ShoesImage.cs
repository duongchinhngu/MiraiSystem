using MiraiSystem.Dtos.BaseDtos;
using MiraiSystem.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiraiSystem.Models
{
    public class ShoesImage : ImageBase
    {
        public string ShoesId { get; set; }
        public virtual Shoes Shoes { get; set; }
    }
}
