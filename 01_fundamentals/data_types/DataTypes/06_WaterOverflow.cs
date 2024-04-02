public static class WaterOverflow
{
    public static void Solve()
    {
        var inputCount = byte.Parse(Console.ReadLine()!);

        short tank = 0;

        for (byte i = 0; i < inputCount; i++)
        {
            var liters = short.Parse(Console.ReadLine()!);
            
            if (tank + liters <= 255)
            {
                tank += liters;
            }
            else
            {
                Console.WriteLine("Insufficient capacity!");
            }
        }

        Console.WriteLine(tank);
    }
}
