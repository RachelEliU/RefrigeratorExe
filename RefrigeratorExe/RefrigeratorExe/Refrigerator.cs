using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefrigeratorExe
{
    internal class Refrigerator
    {
        public Guid id { get; }
        public string Model { get; private set; }
        public string Color { get; private set; }
        public int NumberOfShelfs { get; set; }
        public List<Shelf> Shelves;


        public Refrigerator(string model, string color, int shelf)
        {
            id = new Guid(model);
            Model = model;
            Color = color;
            NumberOfShelfs = shelf;
            Shelves = new List<Shelf>();
            this.AddShelfs();
        }
        public void AddShelfs()
        {
            while (this.Shelves.Count() < this.NumberOfShelfs)
            {
                this.Shelves.Add(new Shelf(this.Shelves.Count()));
            }
        }
        public override string ToString()
        {
            string shelfs = "";
            foreach (Shelf shelf in Shelves)
            {
                shelfs += "\n=================================================================================";
                shelfs += "\n" + shelf.ToString();
            }
            return "Refrigerator id: " + id + " Model: " + Model + " Color: " + Color + " with " + NumberOfShelfs + " shefls containes \n" + shelfs;
        }
    }
}
