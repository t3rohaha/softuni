public static class SumDigits
{
    public static void Solve()
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
