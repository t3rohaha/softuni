namespace DataTypes;

public class WaterOverflow
{
    public static void Main()
    {
        var inputCount = byte.Parse(Console.ReadLine()!);

        short tank = 0;

        for (byte i = 0; i < inputCount; i++)
        {
            var liters = short.Parse(Console.ReadLine()!);
            
            if (tank + liters <= 255) tank += liters;
            else Console.WriteLine("Insufficient capacity!");
        }

        Console.WriteLine(tank);
    }
}