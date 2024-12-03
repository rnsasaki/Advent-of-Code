using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode_Day1
{
    internal class LocationIdSimilarity
    {
        public void CalculateSimilarity(string filePath)
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

            var frequencyMap = new Dictionary<int, int>();
            foreach (int item in list2)
            {
                if (frequencyMap.ContainsKey(item))
                    frequencyMap[item]++;
                else
                    frequencyMap[item] = 1;
            }

            int totalSimilarityScore = 0;
            foreach (int item in list1)
            {
                if (frequencyMap.TryGetValue(item, out int count))
                {
                    totalSimilarityScore += item * count;
                }
            }

            Console.WriteLine(totalSimilarityScore);
        }
    }
}
