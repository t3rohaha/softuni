namespace Exam01;

public class BasketballTournament
{
    public static void Main()
    {
        var totalGames = 0f;
        var wins = 0f;
        var loses = 0f;

        while (true)
        {
            var tournamentName = Console.ReadLine()!;

            if (tournamentName == "End of tournaments") break;

            var gamesCount = byte.Parse(Console.ReadLine()!);

            for (byte i = 0; i < gamesCount; i++)
            {
                var allyScore = byte.Parse(Console.ReadLine()!);
                var enemyScore = byte.Parse(Console.ReadLine()!);
                var diff = Math.Abs(allyScore - enemyScore);

                if (allyScore > enemyScore)
                {
                    wins++;
                    Console.WriteLine($"Game {i+1} of tournament {tournamentName}: win with {diff} points.");
                }
                else
                {
                    loses++;
                    Console.WriteLine($"Game {i+1} of tournament {tournamentName}: lost with {diff} points.");
                }
            }

            totalGames += gamesCount;
        }

        Console.WriteLine($"{wins / totalGames * 100:0.00}% matches win");
        Console.WriteLine($"{loses / totalGames * 100:0.00}% matches lost");
    }
}