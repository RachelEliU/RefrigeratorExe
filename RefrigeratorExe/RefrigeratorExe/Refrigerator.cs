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
        public int SpaceInRefrigerator()
        {
            int spaceSum = 0;
            foreach (Shelf shelf in Shelves)
                spaceSum += shelf.Space;
            return spaceSum;
        }
        public void AddItem(Item item)
        {
            //Shelf shelf1;
            foreach (Shelf shelf in Shelves)
            {
                if (shelf.IsSpaceInShelf(item.Space))
                {
                    shelf.AddItem(item);
                    return;
                }
            }
        
            Console.WriteLine("There is no more space in Refrigeratir, you might want to clean rfrigerator!");
        }
        public Item GetItem(string id)
        {
            Item item;
            foreach (Shelf shelf in Shelves)
            {
                item = shelf.InShelf(id);
                if (item != null)
                {
                    shelf.RemoveItem(item);
                    return item;
                }
            }
            Console.WriteLine("There is no item with this id ");
            return null;
        }
        public void CleanRefrigeraot()
        {
            foreach (Shelf shelf in Shelves)
            {
                shelf.CleanShelf();
            }
        }
        public void RemoveItems(List<Item> items)
        {
            foreach (Item itemToRemove in items)
            {
                this.GetItem(itemToRemove.Id.ToString());
            }
        }
        public List<Item> WhatIsThereToEat(string type, string name)
        {
            List<Item> itemsToEst = new List<Item>();
            this.CleanRefrigeraot();
            foreach (Shelf shelf in Shelves)
            {
                itemsToEst.AddRange(shelf.FindItemsByTypeKosher(type, name));
            }
            return itemsToEst;
        }
    }
}
