namespace DataTypes;

public class SpiceMustFlow
{
    public static void Main()
    {
        var startingYield = int.Parse(Console.ReadLine()!);

        int days = 0;
        int yield = startingYield;
        long totalYield = 0;

        while (yield >= 100)
        {
            days++;
            totalYield += yield - 26;
            yield -= 10;
        }

        if (totalYield > 0) totalYield -= 26;

        Console.WriteLine(days);
        Console.WriteLine(totalYield);
    }
}