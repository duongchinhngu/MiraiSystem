using MiraiSystem.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiraiSystem.Models
{
    public class Shoes : Product
    {
        public string Colorway { get; set; }
        public DateTime ReleasedDate { get; set; }

        public ICollection<ShoesImage> ShoesImages { get; set; }
        public ICollection<ConcreteShoes> ConcreteShoes { get; set; }
    }
}
