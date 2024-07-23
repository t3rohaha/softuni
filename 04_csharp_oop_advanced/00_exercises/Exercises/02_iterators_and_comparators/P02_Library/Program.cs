namespace IteratorsAndComparators.P02_Library;
public class Program
{
    public static void Main()
    {
        var library = new Library(
            new Book("Animal Farm", 2003, "George Orwell"),
            new Book("The Documents in the Case", 2002, "Dorothy Sayers", "Robert Eustace"),
            new Book("The Documents in the Case", 1930)
        );

        Console.WriteLine("Library:");
        foreach (var b in library)
            Console.WriteLine(b.ToString());
        Console.WriteLine();

        library.Sort();
        Console.WriteLine("Sorted Library:");
        foreach (var b in library)
            Console.WriteLine(b.ToString());
    }
}