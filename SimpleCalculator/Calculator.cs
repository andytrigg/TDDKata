namespace SimpleCalculator
{
    public static class Calculator
    {
        public static int Add(string numbers)
        {
            if (numbers == "") return 0;
            numbers = numbers.Replace('\n', ',');

            var values = numbers.Split(',');
            var sum = 0;
            foreach (var value in values)
            {
                sum += int.Parse(value);
            }

            return sum;
        }
    }
}