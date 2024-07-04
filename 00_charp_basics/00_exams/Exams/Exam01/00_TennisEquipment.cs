namespace Exam01;

public class TennisEquipment
{
    public static void Main()
    {
        var racketPrice = decimal.Parse(Console.ReadLine()!);
        var racketsCount = int.Parse(Console.ReadLine()!);
        var shoesCount = int.Parse(Console.ReadLine()!);

        var shoesPrice = racketPrice / 6;

        var racketsTotal = racketPrice * racketsCount;
        var shoesTotal = shoesPrice * shoesCount;
        var otherEquipmentTotal = (racketsTotal + shoesTotal) * 0.2m;
        var total = racketsTotal + shoesTotal + otherEquipmentTotal;

        var playerPaymentAmount = 1/8m * total;
        var sponsorsPaymentAmount = 7/8m * total;

        Console.WriteLine($"Price to be paid by Djokovic {Math.Floor(playerPaymentAmount)}");
        Console.WriteLine($"Price to be paid by sponsors {Math.Ceiling(sponsorsPaymentAmount)}");
    }
}
