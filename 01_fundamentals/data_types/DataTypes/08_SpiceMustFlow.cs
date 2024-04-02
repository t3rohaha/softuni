public static class SpiceMustFlow
{
    public static void Solve()
    {
        var startingYield = int.Parse(Console.ReadLine()!);

        var days = 0;
        var totalYield = 0L;
        var yield = startingYield;

        while (yield >= 100)
        {
            days++;
            totalYield += yield - 26;
            yield -= 10;
        }

        if (totalYield > 0)
        {
            totalYield -= 26;
        }

        Console.WriteLine(days);
        Console.WriteLine(totalYield);
    }
}
