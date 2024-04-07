namespace SumDigits;

class Program
{
    static void Main()
    {
        var num = Console.ReadLine()!;

        byte sum = 0;

        for (var i = 0; i < num.Length; i++)
        {
            sum += (byte)char.GetNumericValue(num[i]);
        }

        Console.WriteLine(sum);
    }
}
