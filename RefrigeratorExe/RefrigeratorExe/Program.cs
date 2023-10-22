namespace RefrigeratorExe
{
    internal class Program
    {
       
        static void Main(string[] args)
        {

            bool flag = true;
            int numberPress;
            List<Refrigerator> refrigerators = new List<Refrigerator>();
            Refrigerator refrigerator = new Refrigerator("Samsong","Red",4);
            refrigerators.Add(refrigerator);
            BuildRefrigerators(refrigerators);
            Console.WriteLine("\nWelcome To The Refrigerator App");
            
            while (flag) 
            {
                Console.WriteLine("");
                Console.WriteLine("Press 1 to print out Item in Refrigerator");
                Console.WriteLine("Press 2 to print the amout of place left in Refrigerator");
                Console.WriteLine("Press 3 to add item to Refrigeratoe");
                Console.WriteLine("Press 4 to take out item our of Refrigerator");
                Console.WriteLine("Press 5 to clean Refigerator");
                Console.WriteLine("Press 6 What do you want to eat");
                Console.WriteLine("Press 7 to sort item according to expiry date");
                Console.WriteLine("Press 8 to sort Shelfs acccording to space");
                Console.WriteLine("Press 9 to sort refrigerators according to space");
                Console.WriteLine("Press 10 to get ready for shoping");
                Console.WriteLine("Prss 100 to exit");
                numberPress = InputNumber();
                switch (numberPress)
                {                   
                    case 1:
                        Console.WriteLine(refrigerator.ToString());
                        break;
                    case 2:
                        Console.WriteLine(refrigerator.SpaceInRefrigerator());
                        break;
                    case 3:
                        GetItemFromUser(refrigerator);                      
                        break;
                    case 4:
                        RemoveItemFromRefrigerator(refrigerator);
                        break;
                    case 5:
                        CleanRefrigerator(refrigerator);
                        break;
                    case 6:
                        WhatDoYouWantToEat(refrigerator);
                        break;
                    case 7:
                        CallSortItem(refrigerator);
                        break;
                    case 8:
                        CallSortShelfs(refrigerator);
                        break;
                    case 9:
                        CallSortRefrigerator(refrigerators);
                        break;
                    case 10:
                        ReadyForShopping(refrigerator);
                        break;
                    case 100:
                        flag=false;
                        break;
                    default:
                        break;
                }
            }         

        }
        public static int InputNumber()
        {

            bool isParse = false;
            int inputNumber = 0;
            Console.WriteLine("Please enter one of the folwing numbers");
            isParse = int.TryParse(Console.ReadLine(), out inputNumber);
            if (isParse && ((inputNumber > 0) && (inputNumber <= 10) || inputNumber == 100))
            {
                return inputNumber;
            }
            Console.WriteLine("Invalid number");
            return InputNumber();
        }
        public static string InputName() 
        {
            bool isParse = false;
            string inputString = "";
            Console.WriteLine("Please enter Item Name");
           // isParse = string.TryParse(Console.ReadLine(), out inputNumber);
            inputString = Console.ReadLine();
            if (!inputString.Equals(""))
            {
                return inputString;
            }
            Console.WriteLine("Invalid name");
            return InputName();

        }
        public static string InputType()
        {
            string inputString = "";
            Console.WriteLine("Please enter Item Type");
            // isParse = string.TryParse(Console.ReadLine(), out inputNumber);
            inputString = Console.ReadLine();
            if (!inputString.Equals("") &&(inputString.Equals("Food")||inputString.Equals("Drink")))
            {
                return inputString;
            }
            Console.WriteLine("Illegal type, type must be Food or Drink ");
            return InputName();
        }
        public static string InputKosher()
        {
            string inputString = "";
            Console.WriteLine("Please enter Item Koshrot");
            // isParse = string.TryParse(Console.ReadLine(), out inputNumber);
            inputString = Console.ReadLine();
            if (!inputString.Equals("") &&(inputString.Equals("Milk")|| inputString.Equals("Parve")|| inputString.Equals("Meat")))
            {
                return inputString;
            }
            Console.WriteLine("Illegal type, Kosher must be Milk Parve or Meat");
            return InputKosher();
        }
        public static DateTime InputDate()
        {
            bool isParse = false;
            DateTime inputDate=DateTime.Now;
            Console.WriteLine("Please enter the expry date");
            isParse = DateTime.TryParse(Console.ReadLine(), out inputDate);
            if (isParse && (inputDate.Date)>=DateTime.Now)
            {
                return inputDate;
            }                
            Console.WriteLine("Invalid Date");
            return InputDate();
        }
        public static string InputID()
        {
            string inputId = "";
            Console.WriteLine("Please enter item id");
            inputId = Console.ReadLine();
            if (!inputId.Equals(""))
            {
                return inputId;
            }
            Console.WriteLine("Invalid id");
            return InputID();
        }
        public static int InputSpace()
        {
            bool isParse = false;
            int inputSpace = 0;
            Console.WriteLine("Please enter item space");
            isParse = int.TryParse(Console.ReadLine(), out inputSpace);
            if (isParse)
            {
                return inputSpace;
            }
            Console.WriteLine("Invalid Date");
            return InputSpace();
        }

        public static void GetItemFromUser(Refrigerator refrigerator)
        {
            Console.WriteLine("Let add item to Refrigerator");
            string name =InputName();
            string type =InputType();
            string kosher = InputKosher();
            DateTime date =InputDate();
            int space =InputSpace();
            Item item9 = new Item(name, type, kosher, date, space);
            if (item9 == null)
                Console.WriteLine("item was not Legel");
            else
            {
                if(refrigerator.AddItem(item9))
                    Console.WriteLine("{0} was added to refrigeratoe", item9.Name);
            }
        }
        public static void RemoveItemFromRefrigerator(Refrigerator refrigerator)
        {
            Console.WriteLine("Lets take out a item ");
            String id =InputID();
            Item item10 = refrigerator.GetItem(id.ToString());
            if (item10 != null)
                Console.WriteLine("Here is the {0} " + item10.Name);
            else
                Console.WriteLine("there is not such item");
        }
        public static void WhatDoYouWantToEat(Refrigerator refrigerator)
        {
            List<Item> items = new List<Item>();
            Console.WriteLine("what Do you want to eat? ");
            string typeItem = InputType();
            string kosheritem = InputKosher();
            items = refrigerator.WhatIsThereToEat(typeItem, kosheritem);
            foreach (Item item in items)
                Console.WriteLine(item.ToString());
        }
        public static void CleanRefrigerator(Refrigerator refrigerator)
        {
            List<Item> itemsToRemove=new List<Item>();
            List<Item> items = refrigerator.GetItems();
            itemsToRemove= refrigerator.CleanRefrigeraot("All",DateTime.Now);
            foreach (Item item in items)
            {
                Console.WriteLine(item.ToString());
                if (itemsToRemove.Contains(item))
                    Console.WriteLine("This  Item was removed");
            }
            refrigerator.RemoveItems(itemsToRemove);
        }
        public static List<Refrigerator> SortRefrigerator(List<Refrigerator> refrigerators)
        {
            refrigerators.Sort();
            return refrigerators;
        }
        public static void ReadyForShopping(Refrigerator refrigerator)
        {
            if (refrigerator.SpaceInRefrigerator() < 20)
            {
                refrigerator.CleanRefrigeraot();
                if (refrigerator.SpaceInRefrigerator() < 20)
                {
                    CleanRefrigeratorForShopping(refrigerator);
                }

            }

        }
        public static void CleanRefrigeratorForShopping(Refrigerator refrigerator)
        {
            List<Item> itemsToRemove = new List<Item>();
            itemsToRemove.AddRange(refrigerator.CleanRefrigeraot("Milk", DateTime.Today.AddDays(3)));
            if (refrigerator.SpaceInRefrigerator() < 20)
            {
                itemsToRemove.AddRange(refrigerator.CleanRefrigeraot("Meat", DateTime.Today.AddDays(7)));
                if (refrigerator.SpaceInRefrigerator() < 20)
                {
                    itemsToRemove.AddRange(refrigerator.CleanRefrigeraot("Parve", DateTime.Today.AddDays(1)));
                    if (refrigerator.SpaceInRefrigerator() < 20)
                    {
                        Console.WriteLine("No place in Refrigerator, Not a good time to go shopping!!");
                        return;
                    }
                }
            }
            refrigerator.RemoveItems(itemsToRemove);
        }
        public static void CallSortItem(Refrigerator refrigerator)
        {
            List<Item> items = new List<Item>();
            Console.WriteLine("Here is the list of Items sorted according to expiry Date");
            items = refrigerator.SortItems();
            foreach (Item item in items)
            {
                Console.WriteLine(item.ToString());
            }
        }
        public static void CallSortShelfs(Refrigerator refrigerator)
        {
            List<Shelf> shelves = new List<Shelf>();
            shelves = refrigerator.SortShelf();
            foreach (Shelf shelf in shelves)
            {
                Console.WriteLine("Shelf id {0} shelf space {1}", shelf.Id, shelf.Space);
            }
        }
        public static void CallSortRefrigerator(List<Refrigerator> refrigeratorList)
        {
            List<Refrigerator> refrigeratorsSorted = new List<Refrigerator>();
            refrigeratorsSorted = SortRefrigerator(refrigeratorList);
            foreach (Refrigerator refrigerator in refrigeratorsSorted)
            {
                Console.WriteLine("Refrigerator id {0} Refrigerator space {1}", refrigerator.id, refrigerator.SpaceInRefrigerator());
            }
        }
        public static void BuildRefrigerators(List<Refrigerator> refrigeratorList)
        {
            Console.WriteLine("Adding items to Refrigerators");
            Refrigerator refrigerator1 = new Refrigerator("Samsung 1", "Blue", 3);
            Refrigerator refrigerator2 = new Refrigerator("Basch", "Black", 5);
            refrigerator1.AddItem(new Item("Deli", "Food", "Meat", DateTime.Now.AddDays(2), 12));
            refrigerator1.AddItem(new Item("Milk", "Drink", "Milk", DateTime.Now.AddDays(1), 10));
            refrigerator1.AddItem(new Item("Meat", "Food", "Meat", DateTime.Now.AddDays(3), 15));
            refrigerator2.AddItem(new Item("Deli", "Food", "Meat", DateTime.Now.AddDays(7), 5));
            refrigerator1.AddItem(new Item("Yorgot", "Food", "Milk", DateTime.Now.AddDays(5), 7));
            refrigeratorList.Add(refrigerator1);
            refrigeratorList.Add(refrigerator2);
        }

    }
}