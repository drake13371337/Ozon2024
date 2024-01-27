using System;

namespace Task5
{
    public class Program
    {
        public static void Main(string[] args)
        {
            bool valid = int.TryParse(Console.ReadLine(), out int actionCount);
            for (int i = 0; i < actionCount; i++)
            {
                int inputLength = int.Parse(Console.ReadLine());
                List<int> input = Console.ReadLine().Split(' ').Select(o => int.Parse(o)).ToList();
                List<(int, int)> resultArch = new List<(int, int)>();

                int currentStep = -1001;
                int currentStart = -1001;
                int prevNum = 0;

                if (input.Count == 1)
                {
                    Console.WriteLine(input.Count * 2);
                    Console.WriteLine("{0} {1}", input[0], 0);
                    continue;
                }
                
                for (int k = 0; k < input.Count; k++)
                {
                    if (currentStep == -1001 && currentStart == -1001)
                    {
                        currentStart = input[k];
                        continue;
                    }

                    if (currentStep == -1001 && currentStart != -1001)
                    {
                        if (int.Abs(input[k] - currentStart) == 1)
                        {
                            currentStep = input[k] - currentStart;
                            prevNum = input[k];
                            
                            if (k == input.Count - 1)
                            {
                                resultArch.Add((currentStart, prevNum - currentStart));
                            }
                        }
                        else
                        {
                            resultArch.Add((currentStart, 0));
                            
                            currentStep = -1001;
                            currentStart = input[k];
                            
                            if (k == input.Count - 1)
                            {
                                resultArch.Add((currentStart, 0));
                            }
                        }
                        continue;
                    }
                    
                    if (currentStep != -1001 && currentStart != -1001)
                    {
                        if (prevNum + currentStep == input[k])
                        {
                            prevNum = input[k];
                            
                            if (k == input.Count - 1)
                            {
                                resultArch.Add((currentStart, prevNum - currentStart));
                            }
                        }
                        else
                        {
                            resultArch.Add((currentStart, prevNum - currentStart));
                            
                            currentStep = -1001;
                            currentStart = input[k];
                            
                            if (k == input.Count - 1)
                            {
                                resultArch.Add((currentStart, 0));
                            }
                        }
                    }
                }
                
                string resString = String.Empty;
                for (int j = 0; j < resultArch.Count; j++)
                {
                    if (j == 0)
                        resString += String.Format("{0} {1}", resultArch[j].Item1, resultArch[j].Item2);
                    else
                        resString += String.Format(" {0} {1}", resultArch[j].Item1, resultArch[j].Item2);
                }

                Console.WriteLine(resultArch.Count * 2);
                Console.WriteLine(resString);
            }
        }
        
        
    }
}