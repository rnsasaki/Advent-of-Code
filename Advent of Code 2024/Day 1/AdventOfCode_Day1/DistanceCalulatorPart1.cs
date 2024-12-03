using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode_Day1
{
    internal class LocationIdDistance
    {
        public void CalculateDistance(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);

            List<int> list1 = new List<int>();
            List<int> list2 = new List<int>();

            foreach (string line in lines)
            {
                string[] parts = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (parts.Length >= 2)
                {
                    bool isFirstInt = int.TryParse(parts[0], out int num1);
                    bool isSecondInt = int.TryParse(parts[1], out int num2);

                    if (isFirstInt && isSecondInt)
                    {
                        list1.Add(num1);
                        list2.Add(num2);
                    }
                    else
                    {
                        Console.WriteLine($"cannot convert to integer in for {line}");
                    }
                }
            }

            list1.Sort();
            list2.Sort();

            if (list1.Count != list2.Count)
            {
                Console.WriteLine("Cannot calculate differences.");
                return;
            }

            List<int> combinedList = new List<int>();
            for (int i = 0; i < list1.Count; i++)
            {
                int difference = Math.Abs(list2[i] - list1[i]);
                combinedList.Add(difference);
            }

            int totalSum = combinedList.Sum();

            Console.WriteLine(totalSum);
            
        }
    }

}
