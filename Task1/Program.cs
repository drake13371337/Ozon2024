using System;

namespace Task1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            bool valid = int.TryParse(Console.ReadLine(), out int actionCount);
            for (int i = 0; i < actionCount; i++)
            {
                Dictionary<string, int> ships = new Dictionary<string, int>()
                {
                    {"1", 0}, {"2", 0}, {"3", 0}, {"4", 0}
                };
                
                foreach (var currentChar in Console.ReadLine().Split(' '))
                {
                    ships[currentChar] += 1;
                }

                if (ships["1"] == 4 && ships["2"] == 3 && ships["3"] == 2 && ships["4"] == 1)
                    Console.WriteLine("YES");
                else
                    Console.WriteLine("NO");
            }
        }
    }
}