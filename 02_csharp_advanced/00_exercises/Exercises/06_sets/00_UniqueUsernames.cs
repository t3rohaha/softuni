namespace Sets;
public class UniqueUsernames
{
    public static void Main()
    {
        var n = byte.Parse(Console.ReadLine()!);
        var uniqueUsernames = new HashSet<string>();

        for (byte i = 0; i < n; i++)
            uniqueUsernames.Add(Console.ReadLine()!);

        foreach (string username in uniqueUsernames)
            Console.WriteLine(username);
    }
}