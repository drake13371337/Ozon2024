using System;

namespace Task4
{
    public class Program
    {
        public static void Main(string[] args)
        {
            bool valid = int.TryParse(Console.ReadLine(), out int actionCount);
            for (int i = 0; i < actionCount; i++)
            {
                int peopleCount = int.Parse(Console.ReadLine());
                int min = 15;
                int max = 30;
                bool costil = true;
                for (int j = 0; j < peopleCount; j++)
                {
                    string tempInput = Console.ReadLine();
                    int currentTemp = int.Parse(tempInput.Substring(2, tempInput.Length - 2));
                    string currentChar = tempInput.Substring(0, 2);

                    if (!costil)
                    {
                        Console.WriteLine("-1");
                        continue;
                    }

                    if (currentChar == ">=")
                    {
                        if (max - currentTemp >= 0)
                        {
                            if (min < currentTemp) min = currentTemp;
                            Console.WriteLine(min);
                        }
                        else
                        {
                            costil = false;
                            Console.WriteLine("-1");
                        }
                    }
                    else
                    {
                        if (currentTemp - min >= 0)
                        {
                            if (currentTemp < max) max = currentTemp;
                            Console.WriteLine(min);
                        }
                        else
                        {
                            costil = false;
                            Console.WriteLine("-1");
                        }
                    }
                }
                Console.WriteLine();
            }
        }
    }
}