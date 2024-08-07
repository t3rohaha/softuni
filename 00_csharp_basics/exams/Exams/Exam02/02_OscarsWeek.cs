namespace Exam02;

public class OscarsWeek
{
    public static void Main()
    {
        var movieName = Console.ReadLine()!;
        var hall = Console.ReadLine()!;
        var tickets = int.Parse(Console.ReadLine()!);

        var total = 0m;
        switch (movieName, hall)
        {
            case ("A Star Is Born", "normal"): total = tickets * 7.5m; break;
            case ("A Star Is Born", "luxury"): total = tickets * 10.5m; break;
            case ("A Star Is Born", "ultra luxury"): total = tickets * 13.5m; break;
            case ("Bohemian Rhapsody", "normal"): total = tickets * 7.35m; break;
            case ("Bohemian Rhapsody", "luxury"): total = tickets * 9.45m; break;
            case ("Bohemian Rhapsody", "ultra luxury"): total = tickets * 12.75m; break;
            case ("Green Book", "normal"): total = tickets * 8.15m; break;
            case ("Green Book", "luxury"): total = tickets * 10.25m; break;
            case ("Green Book", "ultra luxury"): total = tickets * 13.25m; break;
            case ("The Favourite", "normal"): total = tickets * 8.75m; break;
            case ("The Favourite", "luxury"): total = tickets * 11.55m; break;
            case ("The Favourite", "ultra luxury"): total = tickets * 13.95m; break;
        }

        Console.WriteLine($"{movieName} -> {total:F2} lv.");
    }
}