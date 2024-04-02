public static class TriplesOfLatinLetters
{
    public static void Solve()
    {
        var n = byte.Parse(Console.ReadLine()!);

        for (byte x = 0; x < n; x++)
        {
            for (byte y = 0; y < n; y++)
            {
                for (byte z = 0; z < n; z++)
                {
                    Console.WriteLine($"{(char)(97+x)}{(char)(97+y)}{(char)(97+z)}");
                }
            }
        }
    }
}
