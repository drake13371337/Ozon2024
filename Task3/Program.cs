using System;
using System.Numerics;

namespace Task2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            bool valid = int.TryParse(Console.ReadLine(), out int actionCount);
            for (int i = 0; i < actionCount; i++)
            {
                string input = Console.ReadLine();
                
                List<string> tablets = new List<string>();
                string currentTablet = String.Empty;
                bool isTablets = true;
                
                while (input.Length >= 0)
                {
                    if (input.Length == 0 && String.IsNullOrEmpty(currentTablet))
                    {
                        break;
                    }
                    if (input.Length < 4 && String.IsNullOrEmpty(currentTablet))
                    {
                        isTablets = false;
                        break;
                    }
                    if (currentTablet.Length < 4)
                    {
                        currentTablet += input[0];
                        input = input.Remove(0, 1);
                        continue;
                    }
                    if (currentTablet.Length == 4)
                    {
                        if (IsChar(currentTablet[0]) && IsNumber(currentTablet[1]) && IsChar(currentTablet[2]) && IsChar(currentTablet[3]))
                        {
                            tablets.Add(currentTablet);
                            currentTablet = String.Empty;
                        }
                        else
                        {
                            if (String.IsNullOrEmpty(input))
                            {
                                isTablets = false;
                                break;   
                            }
                                
                            currentTablet += input[0];
                            input = input.Remove(0, 1);
                            
                            if (IsChar(currentTablet[0]) && IsNumber(currentTablet[1]) && IsNumber(currentTablet[2]) && IsChar(currentTablet[3]) && IsChar(currentTablet[4]))
                            {
                                tablets.Add(currentTablet);
                                currentTablet = String.Empty;
                            }
                            else
                            {
                                isTablets = false;
                                break;
                            }
                        }
                    }
                }

                if (isTablets)
                {
                    string result = String.Empty;
                    for (int j = 0; j < tablets.Count; j++)
                    {
                        result += tablets[j];
                        if (j != tablets.Count - 1)
                            result += ' ';
                    }
                    Console.WriteLine(result);
                }
                else
                {
                    Console.WriteLine("-");
                }
            }
        }

        public static bool IsNumber(char input)
        {
            return (int)'0' <= (int)input && (int)input <= (int)'9';
        }
        
        public static bool IsChar(char input)
        {
            return (int)'A' <= (int)input && (int)input <= (int)'Z';
        }
    }
}