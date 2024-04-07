namespace BeerKegs;

class Program
{
    static void Main()
    {
        var inputCount = byte.Parse(Console.ReadLine()!);

        string biggestKegModel = "";
        double biggestKegSize = 0;

        for (byte i = 0; i < inputCount; i ++)
        {
            string kegModel = Console.ReadLine()!;
            var kegRadius = double.Parse(Console.ReadLine()!);
            var kegHeight = double.Parse(Console.ReadLine()!);

            double kegSize = Math.PI * Math.Pow(kegRadius, 2) * kegHeight;

            if (biggestKegSize < kegSize)
            {
                biggestKegModel = kegModel;
                biggestKegSize = kegSize;
            }
        }

        Console.WriteLine(biggestKegModel);
    }
}
