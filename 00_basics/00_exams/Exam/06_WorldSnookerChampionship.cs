namespace WorldSnookerChampionship;

class Program
{
    static void Main()
    {
        var ticketStage = Console.ReadLine()!;
        var ticketType = Console.ReadLine()!;
        var ticketCount = int.Parse(Console.ReadLine()!);
        var pictureIncluded = Console.ReadLine();

        var total = 0f;

        switch (ticketStage, ticketType)
        {
            case ("Quarter final", "Standard"):
                total = 55.50f;
                break;
            case ("Quarter final", "Premium"):
                total = 105.20f;
                break;
            case ("Quarter final", "VIP"):
                total = 118.90f;
                break;
            case ("Semi final", "Standard"):
                total = 75.88f;
                break;
            case ("Semi final", "Premium"):
                total = 125.22f;
                break;
            case ("Semi final", "VIP"):
                total = 300.40f;
                break;
            case ("Final", "Standard"):
                total = 110.10f;
                break;
            case ("Final", "Premium"):
                total = 160.66f;
                break;
            case ("Final", "VIP"):
                total = 400.00f;
                break;
        }

        total *= ticketCount;

        if (total > 4000) total -= total * 0.25f;       // 25% discount
        else if (total > 2500) total -= total * 0.10f;  // 10% discount

        if (pictureIncluded == "Y" && total <= 4000)
        {
            total += 40f * ticketCount; // Add picture with trophy price
        }

        Console.WriteLine($"{total:0.00}");
    }
}
