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
        public override string ToString()
        {
            string items = "";
            foreach (Item item in Items)
            {
                items = items + "\n______________________________________________";
                items = items + "\n" + item.ToString();
            }
            return "Shelf Id:" + Id + "\nFloor " + Floor + "\nSpace left in shelf" + Space + "Samar" + "\nHere are the items that are on this shelf" + items;
        }
        public void AddItem(Item item)
        {
            Items.Add(item);
            Space -= item.Space;
            item.ShelfItem=this;
            Console.WriteLine("Added Item {0} to shelf number{1}", item.Id, this.Id);
        }
        public bool IsSpaceInShelf(int space)
        {
            return (Space >= space);
        }
        public Item InShelf(string id)
        {
            foreach (var item in this.Items)
            {
                if (item.Id.ToString().Equals(id))
                {
                    return item;
                }
            }
            return null;
        }
        public void RemoveItem(Item item)
        {
            Items.Remove(item);
            item.ShelfItem=null;
        }
        public void CleanShelf()
        {
            List<Item> itemsToRemove = new List<Item>();
            foreach (Item item in Items)
            {
                if (item.ExpiryDate < DateTime.Now)
                {
                    //this.RemoveItem(item);
                    itemsToRemove.Add(item);
                }

            }
            foreach (Item item in itemsToRemove)
                this.RemoveItem(item);
        }
        public List<Item> FindItemsByTypeKosher(String type, string kosher)
        {
            List<Item> items = new List<Item>();
            foreach (Item item in items)
            {
                if (item.Type.Equals(type) && item.Kosher.Equals(kosher) && item.ExpiryDate < DateTime.Now)
                {
                    items.Add(item);
                }
            }
            return items;
        }
    }
}
