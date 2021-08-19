using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiraiSystem.Models.ExtendedModels
{
    public class ExtendedConcreteShoes : ConcreteShoes
    {
        public string ShoesName { get; set; }
        public string MainImageUrl { get; set; }
    }
}
