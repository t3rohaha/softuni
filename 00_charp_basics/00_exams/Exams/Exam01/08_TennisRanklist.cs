namespace Exam01;

public class TennisRanklist
{
    public static void Main()
    {
        var totalTournaments = int.Parse(Console.ReadLine()!);
        var initialPoints = int.Parse(Console.ReadLine()!);
        var pointsWon = 0;
        var tournamentsWon = 0f;

        for (int i = 0; i < totalTournaments; i++)
        {
            var stageReached = Console.ReadLine()!;

            switch (stageReached)
            {
                case "W":
                    pointsWon += 2000;
                    tournamentsWon++;
                    break;
                case "F":
                    pointsWon += 1200;
                    break;
                case "SF":
                    pointsWon += 720;
                    break;
            }
        }

        Console.WriteLine($"Final points: {initialPoints + pointsWon}");
        Console.WriteLine($"Average points: {pointsWon / totalTournaments} ");
        Console.WriteLine($"{tournamentsWon / totalTournaments * 100:0.00}%");
    }
}
