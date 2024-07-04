namespace Exam01;

public class FitnessCenter
{
    public static void Main()
    {
        var visitorsCount = ushort.Parse(Console.ReadLine()!);
        var backTrainersCount = 0f;
        var chestTrainersCount = 0f;
        var legsTrainersCount = 0f;
        var absTrainersCount = 0f;
        var proteinShakeCount = 0f;
        var proteinBarCount = 0f;

        for (var i = 0; i < visitorsCount; i++)
        {
            var activity = Console.ReadLine()!;

            switch (activity)
            {
                case "Back":
                    backTrainersCount++;
                    break;
                case "Chest":
                    chestTrainersCount++;
                    break;
                case "Legs":
                    legsTrainersCount++;
                    break;
                case "Abs":
                    absTrainersCount++;
                    break;
                case "Protein shake":
                    proteinShakeCount++;
                    break;
                case "Protein bar":
                    proteinBarCount++;
                    break;
            }
        }

        var trainersCount = backTrainersCount + chestTrainersCount + legsTrainersCount + absTrainersCount;
        var barVisitorsCount = proteinShakeCount + proteinBarCount;
        var trainersPerc = trainersCount / visitorsCount * 100;
        var barVisitorsPerc = barVisitorsCount / visitorsCount * 100;

        Console.WriteLine($"{backTrainersCount} - back");
        Console.WriteLine($"{chestTrainersCount} - chest");
        Console.WriteLine($"{legsTrainersCount} - legs");
        Console.WriteLine($"{absTrainersCount} - abs");
        Console.WriteLine($"{proteinShakeCount} - protein shake");
        Console.WriteLine($"{proteinBarCount} - protein bar");
        Console.WriteLine($"{trainersPerc:0.00}% - work out");
        Console.WriteLine($"{barVisitorsPerc:0.00}% - protein");
    }
}
