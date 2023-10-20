using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RefrigeratorExe
{
    internal class Item : IComparable<Item>
    {
        public Guid Id { get; }
        public string Name { get; }
        public Shelf ShelfItem { get; set; }
        public string Type { get; set; }
        public string Kosher {  get; set; }
        public DateTime ExpiryDate { get; set; }
        public int Space { get; set; }
        public Item(string name, Shelf shelf, string type, string kosher, DateTime _expiryDate,int space) 
        {
            Id = Guid.NewGuid();
            Name = name;
            ShelfItem = shelf;
            Type = type;
            Kosher = kosher;
            ExpiryDate = _expiryDate;
            Space = space;
        }
        public override string ToString()
        {
            return "Items Id: " +Id.ToString() + "\nItems name: " + Name.ToString() + "\nItems type: " + Type.ToString() + "\nKosher: " + Kosher.ToString() + "\nItem exprie Date: " + ExpiryDate.Date + "\nItems space: " + Space + " Samar";
        }
        public int CompareTo(Item other)
        {
            return (this.ExpiryDate.CompareTo(other.ExpiryDate));
        }
    }
}
