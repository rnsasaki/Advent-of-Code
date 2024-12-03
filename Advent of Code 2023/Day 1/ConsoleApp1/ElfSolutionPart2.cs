using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElfSoulutionPart2
{
    internal class WordCalibration
    {
        private static readonly Dictionary<string, int> wordToDigit = new()
    {
        { "one", 1 }, { "two", 2 }, { "three", 3 }, { "four", 4 },
        { "five", 5 }, { "six", 6 }, { "seven", 7 }, { "eight", 8 },
        { "nine", 9 }
    };

        public void CalibrationWordCalculation(string file)
        {
            string[] fileContent = File.ReadAllLines(file);
            int totalValue = 0;

            foreach (string line in fileContent)
            {
                List<(int value, int index)> digits = new List<(int value, int index)>();

                foreach (var word in wordToDigit.Keys)
                {
                    int index = line.IndexOf(word);
                    while (index != -1)
                    {
                        digits.Add((wordToDigit[word], index));
                        index = line.IndexOf(word, index + 1);
                    }
                }

                for (int i = 0; i < line.Length; i++)
                {
                    if (char.IsDigit(line[i]))
                    {
                        digits.Add((line[i] - '0', i));
                    }
                }

                digits = digits.OrderBy(d => d.index).ToList();

                if (digits.Count >= 2)
                {
                    int firstNum = digits[0].value;
                    int lastNum = digits[digits.Count - 1].value;
                    totalValue += firstNum * 10 + lastNum;
                }
                else if (digits.Count == 1)
                {
                    totalValue += digits[0].value * 11;
                }
            }

            Console.WriteLine(totalValue);
        }
    }
}
