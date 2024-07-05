namespace DataTypes;

public class SumOfChars
{
    static void Main()
    {
        var inputCount = byte.Parse(Console.ReadLine()!);

        short asciiCodesSum = 0;

        for (byte i = 0; i < inputCount; i++)
        {
            asciiCodesSum += (byte)Console.ReadLine()![0];
        }

        Console.WriteLine($"The sum equals: {asciiCodesSum}");
    }
}