namespace RefrigeratorExe
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Welcome To The Refrigerator App");

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
    }
}