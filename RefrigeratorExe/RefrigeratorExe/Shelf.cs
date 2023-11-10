using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefrigeratorExe
{
    internal class Shelf :IComparable<Shelf>
    {
        private int _floor;
        private int _space;
        public int ShelfSpace = 20;
        public Guid Id{ get; }
        public int Floor {
            get
            {
                return _floor;
            }
            private set
            {
                if (value >= 0)
                    _floor = value;
                else
                    throw new ArithmeticException("Illegal floor ,floor must be a positive number");
            }
        }
        public int Space {
            get
            {
                return _space;
            }
            private set
            {
                if (value >= 0)
                    _space = value;
                else
                    throw new ArithmeticException("Illegal space , space must be a positive number");
            }
        }
        public List<Item> Items;
        public Shelf(int floor) 
        {
            try
            {
                Id = Guid.NewGuid();
                Space = ShelfSpace;
                Floor = floor;
                Items = new List<Item>();
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message); 
            }
           
        }
        public override string ToString()
        {
            string items = "";
            string result;
            foreach (Item item in Items)
            {
                items = items + "\n______________________________________________\n";
                items = items + "\n" + item.ToString();
            }
            result = "Shelf Id:" + Id + "\nFloor: " + Floor + "\nSpace left in shelf: " + Space + " Samar";
            if (items.Length != 0)
                result += "\n Here are the items that are on this shelf\n" + items;
            else
                result += "\nNo items on this shelf";
            return result;
            //return "Shelf Id:" + Id + "\nFloor " + Floor + "\nSpace left in shelf" + Space + "Samar" + "\nHere are the items that are on this shelf" + items;
        }
        public void AddItem(Item item)
        {
            Items.Add(item);
            Space -= item.Space;
            item.ShelfItem=this;
            Console.WriteLine("Added Item {0} to shelf number {1}", item.Name, this.Floor);
        }
        public bool IsSpaceInShelf(int space)
        {
            return (Space >= space);
        }
        public Item InShelf(string id)
        {
            foreach (Item item in this.Items)
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
        public List<Item> CleanShelf(string type, DateTime date)
        {
            List<Item> itemsToRemove = new List<Item>();
            foreach (Item item in Items)
            {
                if (item.ExpiryDate < date && ( item.Type.Equals(type) ||type.Equals("All")))
                {
                    //this.RemoveItem(item);
                    itemsToRemove.Add(item);
                }

            }
            return itemsToRemove;
        }
        public List<Item> FindItemsByTypeKosher(String type, string kosher)
        {
            List<Item> items = new List<Item>();
            foreach (Item item in Items)
            {
                if (item.Type.Equals(type) && item.Kosher.Equals(kosher) && item.ExpiryDate > DateTime.Now)
                {
                    items.Add(item);
                }
            }
            return items;
        }
        public int CompareTo(Shelf Other)
        {
            return ((this.Space > Other.Space) ? (-1) : (this.Space == Other.Space) ? 0 : 1);
        }
    }
}
