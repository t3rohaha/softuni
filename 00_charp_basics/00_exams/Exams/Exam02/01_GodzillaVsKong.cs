namespace Exam02;

public class GodzillaVsKong
{
    public static void Main()
    {
        var budget = decimal.Parse(Console.ReadLine()!);
        var extraCount = decimal.Parse(Console.ReadLine()!);
        var clothingPricePerExtra = decimal.Parse(Console.ReadLine()!);

        var clothingPrice = extraCount * clothingPricePerExtra;
        var decorPrice = budget * 0.1m;

        if (extraCount > 150) clothingPrice -= clothingPrice * 0.1m;

        var total = clothingPrice + decorPrice;

        if (total > budget)
        {
            Console.WriteLine("Not enough money!");
            Console.WriteLine($"Wingard needs {(total - budget):F2} leva more.");
        }
        else
        {
            Console.WriteLine("Action!");
            Console.WriteLine($"Wingard starts filming with {(budget - total):F2} leva left.");
        }
    }
}