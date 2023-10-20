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
    }
}