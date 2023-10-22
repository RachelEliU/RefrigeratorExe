using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RefrigeratorExe
{
    internal class Refrigerator :IComparable<Refrigerator>
    {
        private string _model;


        public Guid id { get; }
        public string Model
        {
            get
            {
                return _model;
            }
            private set
            {
                if (!value.Equals(""))
                    _model = value;
                else
                    throw new ArithmeticException("Illegal model ,model must contain a String ");
            }
        }
        public string Color { get; set; }
        public int NumberOfShelfs { get; set; }
        public List<Shelf> Shelves;


        public Refrigerator(string model, string color, int shelf)
        {
            id = Guid.NewGuid();
            try
            {
                Model = model;

            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message); 
            }
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
                shelfs += "\n=================================================================================\n";
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
        public bool AddItem(Item item)
        {
            int count = 0;
            foreach (Shelf shelf in Shelves)
            {
                if (shelf.IsSpaceInShelf(item.Space))
                {
                    shelf.AddItem(item);
                    return true;
                }
                else
                {
                    if (item.Space > shelf.ShelfSpace)
                        count++;
                }

            }
            if (count == this.Shelves.Count)
                Console.WriteLine("There is no shelf with this amount of space this item is too big");
            else
                Console.WriteLine("There is no more space in Refrigeratir, you might want to clean refrigerator!");
            return false;
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
        public List<Item> GetItems()
        {
            List<Item> items = new List<Item>();
            foreach(Shelf shelf in Shelves)
                items.AddRange(shelf.Items);
            return items;
        }
        public void CleanRefrigeraot()
        {
            
            foreach (Shelf shelf in Shelves)
            {
                shelf.CleanShelf();
            }
        }

        public List<Item> CleanRefrigeraot(String Type, DateTime date)
        {
            List<Item> itemsToRemove = new List<Item>();
            foreach (Shelf shelf in Shelves)
            {
                itemsToRemove.AddRange(shelf.CleanShelf(Type, date));
            }
            return itemsToRemove;
        }
        public void RemoveItems(List<Item> items)
        {
            foreach (Item itemToRemove in items)
            {
                if(itemToRemove.ExpiryDate.Date > DateTime.Now)
                    Console.WriteLine("This Item it been removed " + itemToRemove.ToString());
                this.GetItem(itemToRemove.Id.ToString());
            }
        }
        public List<Item> WhatIsThereToEat(string type, string name)
        {
            List<Item> itemsToEat = new List<Item>();
            foreach (Shelf shelf in Shelves)
            {
                itemsToEat.AddRange(shelf.FindItemsByTypeKosher(type, name));
            }
            return itemsToEat;
        }
        public int CompareTo(Refrigerator other)
        {
            return ((this.SpaceInRefrigerator() > other.SpaceInRefrigerator()) ? (-1) : (this.SpaceInRefrigerator() == other.SpaceInRefrigerator()) ? 0 : 1);
        }
        public List<Item> SortItems()
        {
            List<Item> items = new List<Item>();
            foreach (Shelf shelf in this.Shelves)
            {
                items.AddRange(shelf.Items);
            }
            items.Sort();
            return items;
        }
        public List<Shelf> SortShelf()
        {
            List<Shelf> shelfs = new List<Shelf>();
            foreach (Shelf shelf in this.Shelves)
            {
                shelfs.Add(shelf);
            }
            shelfs.Sort();

            return shelfs;
        }
    }
}
