namespace Exam01;

public class BasketballEquipment
{
    public static void Main()
    {
        var fee = decimal.Parse(Console.ReadLine()!); // Basketball practice annual fee

        var shoesPrice = fee - (fee * 0.4m);
        var clothesPrice = shoesPrice - (shoesPrice * 0.2m);
        var ballPrice = 1/4m * clothesPrice;
        var accessoriesPrice = 1/5m * ballPrice;
        var total = fee + shoesPrice + clothesPrice + ballPrice + accessoriesPrice;

        Console.WriteLine(total.ToString("0.00"));
    }
}
