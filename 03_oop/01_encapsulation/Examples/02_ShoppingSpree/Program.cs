namespace ShoppingSpree;

public class Program
{
    public static void Main()
    {
        ShoppingService shoppingService;

        while (true)
        {
            Console.Write("People: ");
            var peopleInput = Console.ReadLine()!;
            Console.Write("Products: ");
            var productsInput = Console.ReadLine()!;

            try
            {
                shoppingService = new ShoppingService(peopleInput, productsInput);
                break;
            }
            catch (ArgumentException ex)
            {
                PrintError(ex.Message);
                continue;
            }
        }

        while (true)
        {
            try
            {
                Console.Write("Person: ");
                var person = Console.ReadLine()!;

                if (person == "END") break;

                Console.Write("Product: ");
                var product = Console.ReadLine()!;

                var success = shoppingService.Shop(person, product);

                if (success) PrintSuccess($"{person} bought {product}");
                else PrintFailure($"{person} can't afford {product}");

            }
            catch (ArgumentException ex)
            {
                PrintError(ex.Message);
                continue;
            }
        }

        PrintPeople(shoppingService.People.ToArray());
    }

    public static void PrintSuccess(string message)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(message);
        Console.ResetColor();
    }

    public static void PrintFailure(string message)
    {
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine(message);
        Console.ResetColor();
    }

    public static void PrintError(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(message);
        Console.ResetColor();
    }

    private static void PrintPeople(ICollection<Person> people)
    {
        foreach (Person p in people)
            Console.WriteLine(p.ToString());
    }
}
