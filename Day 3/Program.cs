using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text.RegularExpressions;

var lines = File.ReadAllLines(@"C:\Users\kenny\Source\Repos\AdventOfCode2023\Day 3\input.txt");

Regex regex = new Regex(@"[0-9]");

List<string> partNumbers = new List<string>();

for (int x = 0; x < lines.Length; x++)
{
    var line = lines[x];

    Console.WriteLine(line);


    for (int i = 0; i < line.Length; i++)
    {
        var letter = line[i];

        //if (letter != '.' && !regex.IsMatch(letter.ToString()))
        //{
        //    continue;
        //}

        if (/*letter != '.' && */regex.IsMatch(letter.ToString()))
        {
            Console.Write(letter);
            var currentIndex = i;
            var endIndex = currentIndex;
            while (endIndex < line.Length -1 && regex.IsMatch(line[endIndex + 1].ToString()))
            {
                Console.Write(line[endIndex + 1]);

                endIndex++;

                //if (endIndex > line.Length - 1)
                //{
                //    break;
                //}
            }
            Console.WriteLine();

            var number = line.Substring(currentIndex, (endIndex + 1) - currentIndex);
            var numberLength = number.Length;

            bool isPart = false;

            if (x == 0)
            {
                var nextLine = lines[x + 1];

                isPart = CheckIfPartTwoLines(currentIndex, numberLength, line, nextLine);
            }

            if (x > 0 && x < lines.Length - 1)
            {
                var nextLine = lines[x + 1];

                var previousLine = lines[x - 1];
                isPart = CheckIfPartThreeLines(currentIndex, numberLength, line, nextLine, previousLine);
            }

            if (x == lines.Length - 1)
            {
                var previousLine = lines[x - 1];
                isPart = CheckIfPartTwoLines(currentIndex, numberLength, line, previousLine);
            }

            //partNumbers.Add();
            if (isPart)
            {
                partNumbers.Add(number);
            }

            i = endIndex;
        }
    }
}

double sum = 0;

foreach (var part in partNumbers)
{
    sum += Int32.Parse(part);
}

Console.WriteLine($"Sum is {sum}");



bool CheckIfPartTwoLines(int currentIndex, int numberLength, string line, string nextLine)
{
    if (currentIndex != 0 && line[currentIndex - 1] != '.')
    {
        return true;
    }

    if ((currentIndex + numberLength < line.Length) && line[currentIndex + numberLength] != '.')
    {
        return true;
    }

    var adjacentLineChars = nextLine.Substring(currentIndex - 1, numberLength + 2);
    Console.WriteLine(adjacentLineChars);

    foreach (char character in adjacentLineChars)
    {
        if (character != '.' && !regex.IsMatch(character.ToString()))
        {
            return true;
        }
    }

    return false;
}

bool CheckIfPartThreeLines(int currentIndex, int numberLength, string line, string nextLine, string previousLine)
{
    if (currentIndex != 0 && !regex.IsMatch(line[currentIndex - 1].ToString()) && line[currentIndex - 1] != '.')
    {
        Console.WriteLine(line[currentIndex - 1]);

        return true;
    }

    if ((currentIndex + numberLength < line.Length) && !regex.IsMatch(line[currentIndex + numberLength].ToString()) && line[currentIndex + numberLength]!= '.')
    {
        Console.WriteLine(line[currentIndex + numberLength]);

        return true;
    }
    string adjacentTopChars = string.Empty;

    if (currentIndex == 0)
    {
        var subStringLength = numberLength + 1;

        if (currentIndex + numberLength + 1 > previousLine.Length)
        {
            subStringLength = currentIndex + numberLength + 1 - previousLine.Length;
        }


        adjacentTopChars = previousLine.Substring(currentIndex, subStringLength);

    }
    else
    {
        var subStringLength = numberLength + 2;

        if (currentIndex + numberLength + 2 > previousLine.Length)
        {
            subStringLength =  currentIndex + numberLength + 1 - previousLine.Length;
        }

        adjacentTopChars = previousLine.Substring(currentIndex - 1, subStringLength);
    }
    Console.WriteLine(adjacentTopChars);

    foreach (char character in adjacentTopChars)
    {
        if (character != '.' && !regex.IsMatch(character.ToString()))
        {
            return true;
        }
    }
    string adjacentBottomChars = string.Empty;

    if (currentIndex == 0)
    {
        var subStringLength = numberLength + 1;

        if (currentIndex + numberLength + 1 > nextLine.Length)
        {
            subStringLength = currentIndex + numberLength + 1 - nextLine.Length;
        }

        adjacentBottomChars = nextLine.Substring(currentIndex, subStringLength);

    }
    else
    {
        var subStringLength = numberLength + 2;

        if (currentIndex + numberLength + 2 > nextLine.Length)
        {
            subStringLength = currentIndex + numberLength + 2 - nextLine.Length;
        }

        adjacentBottomChars = nextLine.Substring(currentIndex - 1, subStringLength);

    }
    Console.WriteLine(adjacentBottomChars);

    foreach (char character in adjacentBottomChars)
    {
        if (character != '.' && !regex.IsMatch(character.ToString()))
        {
            return true;
        }
    }

    return false;
}