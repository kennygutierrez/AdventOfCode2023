using System;
using System.Text.RegularExpressions;

namespace Day_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var lines = File.ReadAllLines(@"C:\Users\kenny\Source\Repos\AdventOfCode2023\Day 4\input.txt");

            var grandTotal = 0;

            foreach (var line in lines)
            {
                var numbers = line.Split(':');
                var winningNumbers = numbers[1].Trim().Replace("  ", " ").Split('|')[0];
                var myNumbers = numbers[1].Trim().Replace("  ", " ").Split('|')[1];

                var matches = 0;


                var individualWinningNumbers = winningNumbers.Trim().Split(" ").ToList();
                var individualMyNumbers = myNumbers.Trim().Split(" ").ToList();

                foreach (var winningNumber in individualWinningNumbers)
                {
                    if (individualMyNumbers.Contains(winningNumber))
                    {
                        matches++;
                    }
                }
                grandTotal += points(matches);
            }
            Console.WriteLine($"Grand Total: {grandTotal}");

            //part 2

            var totalCards = 0;

            for (int i = 0; i < lines.Length; i++)
            {
                int cards = ProcessCard(lines, i, 0);

                totalCards = totalCards + cards;
            }
            Console.WriteLine($"Total Cards: {totalCards}");
        }

        private static int ProcessCard(string[] lines, int index, int copies)
        {
            
            Console.WriteLine(lines[index]);

            if (index + 1 == lines.Length)
            {
                return copies + 1;
            }

            var line = lines[index];

            var numbers = line.Split(':');
            var winningNumbers = numbers[1].Trim().Replace("  ", " ").Split('|')[0];
            var myNumbers = numbers[1].Trim().Replace("  ", " ").Split('|')[1];

            var individualWinningNumbers = winningNumbers.Trim().Split(" ").ToList();
            var individualMyNumbers = myNumbers.Trim().Split(" ").ToList();

            foreach (var winningNumber in individualWinningNumbers)
            {

                if (individualMyNumbers.Contains(winningNumber))
                {
                    copies++;
                }
            }

            return ProcessCard(lines, index + 1, copies + 1);
        }

        private static int points(int n)
        {
            if (n == 0) return 0;

            var points = 1;

            for (int i = 1; i < n; i++)
            {
                points = points * 2;
            }

            return points;
        }
    }
}