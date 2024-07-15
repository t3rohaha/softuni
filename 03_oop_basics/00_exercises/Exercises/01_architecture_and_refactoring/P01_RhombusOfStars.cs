namespace ArchitectureAndRefactoring.P01_RhombusOfStars;
public class Program
{
    public static void Main()
    {
        var n = int.Parse(Console.ReadLine()!);

        PrintRhombus(n);
    }

    static void PrintRhombus(int size)
    {
        for (var i = 1; i <= size; i++)
            PrintRow(size - i, i);

        for (var i = size - 1; i > 0; i--)
            PrintRow(size - i, i);
    }

    static void PrintRow(int spaces, int stars)
    {
        Console.Write(new string(' ', spaces));
        Console.Write(string.Concat(Enumerable.Repeat("* ", stars)).Trim());
        Console.Write(new string(' ', spaces));
        Console.WriteLine();
    }
}