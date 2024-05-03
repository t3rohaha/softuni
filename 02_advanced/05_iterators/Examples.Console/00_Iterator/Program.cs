namespace Iterator;

public class Program
{
    public static void Main()
    {
        foreach (int n in GetNumbers()) Console.WriteLine(n);
    }

    static IEnumerable<int> GetNumbers()
    {
        yield return 1;

        Console.WriteLine("Hello from Iterator 1.");

        yield return 2;

        Console.WriteLine("Hello from iterator 2.");

        yield return 3;
    }
}