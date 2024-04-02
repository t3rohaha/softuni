public static class BeerKegs
{
    public static void Solve()
    {
        var inputCount = byte.Parse(Console.ReadLine()!);

        var biggestKegModel = "";
        var biggestKegSize = 0D;

        for (byte i = 0; i < inputCount; i ++)
        {
            var kegModel = Console.ReadLine()!;
            var kegRadius = double.Parse(Console.ReadLine()!);
            var kegHeight = double.Parse(Console.ReadLine()!);

            var kegSize = Math.PI * Math.Pow(kegRadius, 2) * kegHeight;

            if (biggestKegSize < kegSize)
            {
                biggestKegModel = kegModel;
                biggestKegSize = kegSize;
            }
        }

        Console.WriteLine(biggestKegModel);
    }
}
