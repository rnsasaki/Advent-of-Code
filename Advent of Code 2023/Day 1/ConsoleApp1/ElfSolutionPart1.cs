using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace ElfSoulutionPart1
{
    public class Calibration
    {
        public void CalibrationValueCalculation(string file)
        {
            string[] fileContent = File.ReadAllLines(file);
            int totalValue = 0;

            foreach (string line in fileContent)
            {
                var digits = line.Where(c => char.IsDigit(c)).ToArray();

                if (digits.Length >= 2)
                {
                    int firstNum = digits[0] - '0';
                    int lastNum = digits[digits.Length - 1] - '0';

                    totalValue += firstNum * 10 + lastNum;
                }
                else
                {
                    int firstNum = digits[0] - '0';
                    totalValue += firstNum * 10 + firstNum;
                }

            }

            Console.WriteLine(totalValue);
        }
    }
}
