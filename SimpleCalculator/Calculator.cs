using System;
using System.Collections.Generic;

namespace SimpleCalculator
{
    public static class Calculator
    {
        public static int Add(string numbers)
        {
            if (numbers == "") return 0;

            var delimiter = ',';
            if (numbers.StartsWith("//"))
            {
                delimiter = numbers[2];
                numbers = numbers.Substring(4);
            }
            numbers = numbers.Replace('\n', delimiter);

            var values = numbers.Split(delimiter);
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
                throw new ArgumentException(string.Join(",", negativeNumbers));
            }

            return sum;
        }
    }
}