using System;
using System.Collections.Generic;

namespace SimpleCalculator
{
    public static class Calculator
    {
        public static int Add(string numbers)
        {
            if (numbers == "") return 0;
            var delimiters = DetermineDelimiters(ref numbers);
            numbers = numbers.Replace("\n", delimiters[0]);
            return SumValues(numbers, delimiters);
        }

        private static int SumValues(string numbers, string[] delimiters)
        {
            var values = numbers.Split(delimiters, StringSplitOptions.None);
            var sum = 0;
            var negativeNumbers = new List<int>();

            foreach (var value in values)
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException();

                var number = int.Parse(value);
                if (number > 1000)
                    number = 0;
                if (number < 0)
                    negativeNumbers.Add(number);
                sum += number;
            }

            if (negativeNumbers.Count > 0)
            {
                throw new ArgumentException($"negatives not allowed: {string.Join(",", negativeNumbers)}");
            }

            return sum;
        }

        private static string[] DetermineDelimiters(ref string numbers)
        {
            var delimiters = new[] {","};
            if (numbers.StartsWith("//["))
            {
                var posLineFeed = numbers.IndexOf('\n');
                delimiters = numbers.Substring(3, posLineFeed - 4).Replace("]", "").Split("[");
                numbers = numbers.Substring(posLineFeed + 1);
            }
            else if (numbers.StartsWith("//"))
            {
                delimiters[0] = numbers[2].ToString();
                numbers = numbers.Substring(4);
            }

            return delimiters;
        }
    }
}