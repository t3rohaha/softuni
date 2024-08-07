namespace Exam02;

public class OscarsCeremony
{
    public static void Main()
    {
        var rent = decimal.Parse(Console.ReadLine()!);
        var prize = rent - (rent * 0.3m);
        var catering = prize - (prize * 0.15m);
        var music = catering / 2;

        var total = rent + prize + catering + music;

        Console.WriteLine($"{total:.00}");
    }
}