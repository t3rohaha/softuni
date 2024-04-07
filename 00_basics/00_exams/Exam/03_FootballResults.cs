namespace FootballResults;

class Program
{
    static void Main()
    {
        int wins = 0, loses = 0, draws = 0;

        for (var i = 0; i < 3; i++)
        {
            var result = Console
            .ReadLine()!
            .Split(":")
            .Select(int.Parse)
            .ToArray();

            if (result[0] > result[1]) wins++;
            else if (result[0] < result[1]) loses++;
            else draws++;
        }

        Console.WriteLine($"Team won {wins} games.");
        Console.WriteLine($"Team lost {loses} games.");
        Console.WriteLine($"Drawn games: {draws}");
    }
}
