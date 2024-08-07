namespace DataTypes;

public class PrintPartOfAsciiTable
{
    public static void Main()
    {
        var start = byte.Parse(Console.ReadLine()!);
        var end = byte.Parse(Console.ReadLine()!);

        var asciiChars = "";
        for (byte i = start; i <= end; i++)
        {
            asciiChars += (char)i + " ";
        }

        Console.WriteLine(asciiChars.Trim());
    }
}