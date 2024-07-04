namespace Exam01;

public class Gymnastics
{
    public static void Main()
    {
        var country = Console.ReadLine()!;
        var equipment = Console.ReadLine()!;

        var maxScore = 20;
        var score = 0f;

        switch (country, equipment)
        {
            case ("Bulgaria", "hoop"):
                score = 19.300f;
                break;
            case ("Bulgaria", "ribbon"):
                score = 19.000f;
                break;
            case ("Bulgaria", "rope"):
                score = 18.900f;
                break;
            case ("Italy", "hoop"):
                score = 18.800f;
                break;
            case ("Italy", "ribbon"):
                score = 18.700f;
                break;
            case ("Italy", "rope"):
                score = 18.850f;
                break;
            case ("Russia", "hoop"):
                score = 19.100f;
                break;
            case ("Russia", "ribbon"):
                score = 18.500f;
                break;
            case ("Russia", "rope"):
                score = 18.600f;
                break;
        }

        var percentageAchieved = score / maxScore * 100;
        var percentageLacking = 100 - percentageAchieved;

        Console.WriteLine($"The team of {country} get {score:0.000} on {equipment}.");
        Console.WriteLine($"{percentageLacking:0.00}%");
    }
}
