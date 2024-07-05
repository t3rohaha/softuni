namespace DataTypes;
using System.Numerics;

public class Snowballs
{
    public static void Main()
    {
        var snowballsCount = byte.Parse(Console.ReadLine()!);
        BigInteger maxSnowballValue = 0;
        string outputFormula = "";

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