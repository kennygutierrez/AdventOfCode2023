var games = File.ReadAllLines(@"C:\Users\kenny.gutierrez\source\repos\Advent Of Code\Day 2\input.txt");

const int redCount = 12;
const int greenCount = 13;
const int blueCount = 14;

var possibleCount = 0;
var totalPower = 0;

foreach (var game in games)
{
    var roundNum = Int32.Parse(game.Split(':')[0].Replace("Game ", string.Empty));

    var results = game.Split(':')[1];

    var rounds = results.Split(';');

    var possible = false;

    foreach (var round in rounds)
    {
        var colorCounts = round.Split(",");

        int.TryParse( colorCounts.FirstOrDefault(x => x.Contains("red"))?.Replace(" red", string.Empty), out var redResults);
        int.TryParse(colorCounts.FirstOrDefault(x => x.Contains("blue"))?.Replace(" blue", string.Empty), out var blueResults);
        int.TryParse(colorCounts.FirstOrDefault(x => x.Contains("green"))?.Replace(" green", string.Empty), out var greenResults);

        possible = redResults <= redCount && blueResults <= blueCount && greenResults <= greenCount;

        if (!possible)
        {
            break;
        }
    }

    if (possible)
    {
        possibleCount += roundNum;
    }
}

Console.WriteLine($"Sum of Game Ids is {possibleCount}");

//part 2

foreach (var game in games)
{
    var results = game.Split(':')[1];

    var rounds = results.Split(';');

    var highestRed = 0;
    var highestGreen = 0;
    var highestBlue = 0;

    foreach (var round in rounds)
    {
        string[] colorCounts = round.Split(",");

        int.TryParse(colorCounts.FirstOrDefault(x => x.Contains("red"))?.Replace(" red", string.Empty), out var redResults);
        int.TryParse(colorCounts.FirstOrDefault(x => x.Contains("blue"))?.Replace(" blue", string.Empty), out var blueResults);
        int.TryParse(colorCounts.FirstOrDefault(x => x.Contains("green"))?.Replace(" green", string.Empty), out var greenResults);

        if (redResults > highestRed) { highestRed = redResults; }
        if (greenResults > highestGreen) { highestGreen = greenResults; }
        if (blueResults > highestBlue) { highestBlue = blueResults; }
    }

    totalPower += highestBlue * highestGreen * highestRed;
}

Console.WriteLine($"Total power is {totalPower}");