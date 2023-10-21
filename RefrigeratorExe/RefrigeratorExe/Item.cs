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
        private string _kosher;
        private string _name;
        private DateTime _date;
        private int _space;
        public Guid Id { get; }
        public string Name
        {
            get
            {
                return _name;
            }
            private set
            {
                if (!value.Equals(""))
                    _name = value;
                else
                    throw new ArithmeticException("Illegal name , name must contain a String ");
            }
        }
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
                    throw new ArithmeticException("Illegal type , type must be Food or Drink ");
            }
        }
        public string Kosher {
            get
            {
                return _kosher;
            }
            private set
            {
                if (value.Equals("Milk") || value.Equals("Meat") || value.Equals("Parve"))
                    _kosher = value;
                else
                    throw new ArithmeticException("Illegal kosher , kosher must be Milk,Meat or Parve ");
            }
        }
        public DateTime ExpiryDate
        {
            get
            {
                return _date;
            }
            private set
            {
                if (value > DateTime.Now)
                    _date = value;
                else
                    throw new ArithmeticException("Illegal Date ,expire date must be after today");
            }
        }
        public int Space
        {
            get
            {
                return _space;
            }
            private set
            {
                if (value>=0)
                    _space = value;
                else
                    throw new ArithmeticException("Illegal space , space must be a positive number");
            }
        }
        public Item(string name,string type, string kosher, DateTime _expiryDate,int space) 
        {
            try
            {
                Id = Guid.NewGuid();
                Name = name;
                Type = type;
                Kosher = kosher;
                ExpiryDate = _expiryDate;
                Space = space;
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }

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
