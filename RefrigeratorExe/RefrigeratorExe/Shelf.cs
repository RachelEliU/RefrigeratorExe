using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefrigeratorExe
{
    internal class Shelf
    {
        public Guid Id{ get; }
        public int Floor { get; set; }
        public int Space { get; set; }
        public List<Item> Items;
        public Shelf(int floor) 
        { 
            Id = Guid.NewGuid();
            Space = 20;
            Floor = floor;
            Items = new List<Item>();
        }
    }
}
