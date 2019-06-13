using System;
using System.Linq;

namespace StringCalculator
{
    public class Calculator
    {
        public static int Add(string numberString)
        {
            var returnValue = 0;
            var separators = generateSeparators(numberString);
            numberString.Split(separators).ToList().ForEach(n =>
            {
                returnValue += int.TryParse(n, out var b) ? b : 0;
            });

            return returnValue;
        }

        private static char[] generateSeparators(string numberString)
        {
            var separators = new System.Collections.Generic.List<char>{',', '\n'};
            if (numberString.StartsWith("\\"))
            {
                separators.Add(numberString[2]);
            }

            return separators.ToArray();
        }
    }
}