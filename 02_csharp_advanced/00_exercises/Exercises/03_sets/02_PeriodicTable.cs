namespace Sets;

public class PeriodicTable
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine()!);

        var uniqueEls = new HashSet<string>();
        for (int i = 0; i < n; i++)
            uniqueEls.UnionWith(Console.ReadLine()!.Split(" "));

        Console.WriteLine(string.Join(" ", uniqueEls.OrderBy(x => x)));        
    }
}
