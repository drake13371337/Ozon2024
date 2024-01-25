using System;

namespace Task2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            bool valid = int.TryParse(Console.ReadLine(), out int actionCount);
            for (int i = 0; i < actionCount; i++)
            {
                string [] date = Console.ReadLine().Split(' ');
                try
                {
                    DateTime newDate = new DateTime(int.Parse(date[2]), int.Parse(date[1]), int.Parse(date[0]));
                }
                catch (Exception e)
                {
                    Console.WriteLine("NO");
                    continue;
                }
                Console.WriteLine("YES");
            }
        }
    }
}