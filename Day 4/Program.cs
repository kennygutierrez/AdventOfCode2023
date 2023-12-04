namespace Day_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var lines = File.ReadAllLines(@"C:\Users\kenny.gutierrez\source\repos\Advent Of Code\Day 4\input.txt");

            foreach (var line in lines)
            {
                var numbers = line.Split(':');
                var winningNumbers = numbers[1].Replace("  ", " ").Split('|')[0];
                var myNumbers = numbers[1].Replace("  ", " ").Split('|')[1];

                var matches = 0;
                var grandTotal = 0;

                var individualWinningNumbers = winningNumbers.Split(" ").ToList();
                var individualMyNumbers = myNumbers.Split(" ").ToList();

                foreach (var winningNumber in individualWinningNumbers)
                {
                    if (individualMyNumbers.Contains(winningNumber))
                    {
                        matches++;
                    }
                }

                Console.WriteLine($"Matches: {matches}, Points: {points(matches)}");
                Console.WriteLine($"Grand Total: {grandTotal}");
            }
        }

        private static long points(int n)
        {
            var points = 0;

            for (int i = 1; i < n; i++)
            {
                points = i * 2;
            }

            return points + 1;
        }
    }
}