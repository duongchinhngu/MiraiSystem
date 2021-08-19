using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiraiSystem.Models
{
    public class ConcreteShoes
    {
        public int Id  { get; set; }
        public string ShoesId  { get; set; }
        public virtual Shoes Shoes { get; set; }
        public double Size  { get; set; }
        public string Gender  { get; set; }
        public int Quantity  { get; set; }
        public double Price { get; set; }
    }
}
