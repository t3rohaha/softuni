namespace RandomList;

public class Program
{
    public static void Main()
    {
        var randomList = new RandomList<int>() { 1, 2, 3, 4, 5, 6, 7, 8 };

        Console.WriteLine(randomList.RemoveRandom());
        Console.WriteLine(randomList.RemoveRandom());
        Console.WriteLine(randomList.RemoveRandom());
        Console.WriteLine(randomList.RemoveRandom());
    }
}