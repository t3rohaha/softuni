namespace FunctionalProgramming;

public class Basics
{
    public static void Main()
    {
        Sum sum = (x, y) => x + y;

        Console.WriteLine(sum(5, 5));
    }

    delegate int Sum(int x, int y);
}