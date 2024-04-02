using System.Numerics;

public static class Snowballs
{
    public static void Solve()
    {
        var snowballsCount = byte.Parse(Console.ReadLine()!);

        var outputFormula = "";
        BigInteger maxSnowballValue = 0;
        for (byte i = 0; i < snowballsCount; i++)
        {
            var snowballSnow = int.Parse(Console.ReadLine()!);
            var snowballTime = int.Parse(Console.ReadLine()!);
            var snowballQuality = int.Parse(Console.ReadLine()!);

            var snowballValue = BigInteger.Pow(snowballSnow / snowballTime, snowballQuality);

            if (snowballValue > maxSnowballValue)
            {
                maxSnowballValue = snowballValue;
                outputFormula = $"{snowballSnow} : {snowballTime} = {snowballValue} ({snowballQuality})";
            }
        }

        Console.WriteLine(outputFormula);
    }
}
