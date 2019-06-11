using System;

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
            foreach (var value in values)
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException();

                var number = int.Parse(value);
                if (number < 0)
                    throw new ArgumentException();
                sum += number;
            }

            return sum;
        }
    }
}