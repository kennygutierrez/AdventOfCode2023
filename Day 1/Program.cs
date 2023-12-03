var lines = File.ReadAllLines(@"C:\Users\kenny.gutierrez\source\repos\Advent Of Code\Day 1\input.txt");

var total = 0;

foreach (var line in lines)
{
    var chars = new char[2];

    foreach (var ch in line.Where(char.IsNumber))
    {
        chars[0] = ch;
        break;
    }

    foreach (var ch in line.Reverse())
    {
        if (char.IsNumber(ch))
        {
            chars[1] = ch;
            break;
        }
    }

    var twoDigitInt = int.Parse(new string(chars));

    total += twoDigitInt;
}

Console.WriteLine($"Part 1 Grand total is {total}");

//part 2

var partTwoTotal = 0;

foreach (var line in lines)
{
    Dictionary<int, int> matches = new();

    var numbersArray1 = new[] { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine"};

    var numbersArray2 = new[] { "1", "2", "3", "4", "5", "6", "7", "8", "9" };

    for (int i = 0; i < numbersArray1.Length; i++)
    {
        if (line.Contains(numbersArray1[i]))
        {
            AddMatches(matches, line, numbersArray1[i], i+1);
        }
    }

    for (int i = 0; i < numbersArray2.Length; i++)
    {
        if (line.Contains(numbersArray2[i]))
        {
            AddMatches(matches, line, numbersArray2[i], i + 1);
        }
    }

    var firstNumberMatch = matches.MinBy(x => x.Key);
    var firstNumber = firstNumberMatch.Value;

    var secondNumberMatch = matches.MaxBy(x => x.Key);
    var secondNumber = secondNumberMatch.Value;

    var twoDigitInt = int.Parse(firstNumber + secondNumber.ToString());

    partTwoTotal += twoDigitInt;

}

Console.WriteLine($"Part 2 Grand total is {partTwoTotal}");
return;

static void AddMatches(IDictionary<int, int> matches, string line, string searchTerm, int numberTerm)
{
    var foundAt = line.IndexOf(searchTerm, StringComparison.Ordinal);
    matches.Add(foundAt, numberTerm);

    if (line.LastIndexOf(searchTerm, StringComparison.Ordinal) > foundAt)
    {
        matches.Add(line.LastIndexOf(searchTerm, StringComparison.Ordinal), numberTerm);
    }
}