namespace IntegerOperations;

class Program
{
    static void Main()
    {
        long number = long.Parse(Console.ReadLine()!);
        
        long addend = long.Parse(Console.ReadLine()!);
        number += addend;

        long divisor = long.Parse(Console.ReadLine()!);
        number /= divisor;

        long multiplier = long.Parse(Console.ReadLine()!);
        number *= multiplier;

        Console.WriteLine(number);
    }
}
