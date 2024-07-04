namespace Exam01;

public class Darts
{
    public static void Main()
    {
        var playerName = Console.ReadLine()!;
        var totalPoints = 301;
        var successfulShots = 0;
        var unsuccessfulShots = 0;

        while (true)
        {
            var cmd = Console.ReadLine()!;

            if (cmd == "Retire") break;    // Exit

            var points = int.Parse(Console.ReadLine()!);

            if (cmd == "Double") points *= 2;
            else if (cmd == "Triple") points *= 3;

            if (totalPoints - points >= 0)
            {
                totalPoints -= points;
                successfulShots++;
            }
            else unsuccessfulShots++;

            if (totalPoints == 0) break;    // Exit
        }

        if (totalPoints == 0)
            Console.WriteLine($"{playerName} won the leg with {successfulShots} shots.");
        else
            Console.WriteLine($"{playerName} retired after {unsuccessfulShots} unsuccessful shots.");
    }
}
