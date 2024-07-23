namespace IteratorsAndComparators.P00_Iterator;
public class Program
{
    public static void Main()
    {
        foreach (int n in GetNumbers())
            Console.WriteLine(n);
    }

    static IEnumerable<int> GetNumbers()
    {
        yield return 1;

        Console.WriteLine("Hello from GetNumbers iterator method, after returning first value.");

        yield return 2;

        Console.WriteLine("Hello from GetNumbers iterator method, after returning second value.");

        yield return 3;

        Console.WriteLine("Hello from GetNumbers iterator method, after returning third value, which is the last one.");
    }
}