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
        private string _type;
        private string _kosger;
        public Guid Id { get; }
        public string Name { get; }
        public Shelf ShelfItem { get; set; }
        public string Type
        {
            get
            {
                return _type;
            }
              private set
            {
                if (value.Equals("Food") || value.Equals("Drink"))
                    _type = value;
                else
                    Console.WriteLine("Illegal type , type must be Food or Drink ");
            }
        }
        public string Kosher {  get;  private set; }
        public DateTime ExpiryDate { get; set; }
        public int Space { get; set; }
        public Item(string name,string type, string kosher, DateTime _expiryDate,int space) 
        {
            Id = Guid.NewGuid();
            Name = name;
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
