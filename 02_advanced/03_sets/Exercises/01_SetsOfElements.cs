namespace SetsOfElements;

class Program
{
    static void Main()
    {
        int[] input = Console
        .ReadLine()!
        .Split(' ')
        .Select(int.Parse)
        .ToArray();

        int n = input[0];
        var s1 = new HashSet<int>();
        for (int i = 0; i < n; i++)
            s1.Add(int.Parse(Console.ReadLine()!));

        int m = input[1];
        var s2 = new HashSet<int>();
        for (int i = 0; i < m; i++)
            s2.Add(int.Parse(Console.ReadLine()!));

        Console.WriteLine(string.Join(" ", s1.Intersect(s2)));
    }
}
