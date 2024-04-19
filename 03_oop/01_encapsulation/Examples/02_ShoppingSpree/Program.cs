using System.Text.RegularExpressions;
using ShoppingSpree.Models;

namespace ShoppingSpree;

public class Program
{
    public static void Main()
    {
        var people = GetPeople();
        var products = GetProducts();
        StartShopping(people, products);
        PrintPeople(people);
    }

    private static void PrintPeople(ICollection<Person> people)
    {
        foreach (Person p in people)
            Console.WriteLine(p.ToString());
    }

    private static void StartShopping(ICollection<Person> people, ICollection<Product> products)
    {
        while (true)
        {
            Console.Write("Enter person name and product name separated with spaces: ");

            var input = Console.ReadLine()!;

            if (input == "END") break;

            string[] args = input.Split(" ");

            var person = people.FirstOrDefault(x => x.Name == args[0]);

            if (person == null)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Person not found!");
                Console.ResetColor();
                continue;
            }

            var product = products.FirstOrDefault(x => x.Name == args[1]);

            if (product == null)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Product not found!");
                Console.ResetColor();
                continue;
            }

            var success = person.BuyProduct(product);
            if (!success)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine($"{person.Name} can't afford {product.Name}");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{person.Name} bought {product.Name}");
                Console.ResetColor();
            }
        }

    }

    private static ICollection<Person> GetPeople()
    {
        Console.Write("Enter list of people in format (name=money;name=money etc...): ");

        var peopleInput = Console.ReadLine()!;

        var regex = new Regex(@"(?<name>[A-Za-z]+)=(?<money>[0-9]+(?:\.[0-9]+)?)");

        var people = new List<Person>();

        try
        {
            foreach (Match match in regex.Matches(peopleInput))
            {
                var name = match.Groups["name"].Value;
                var money = decimal.Parse(match.Groups["money"].Value);
                people.Add(new Person(name, money));
            }
        }
        catch (ArgumentException ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(ex.Message);
            Console.ResetColor();
            Environment.Exit(1);
        }

        return people;
    }

    private static ICollection<Product> GetProducts()
    {
        Console.Write("Enter list of products in format (name=price;name=price etc...): ");

        var input = Console.ReadLine()!;

        var regex = new Regex(@"(?<name>[A-Za-z]+)=(?<price>[0-9]+(?:\.[0-9]+)?)");

        var products = new List<Product>();

        try
        {
            foreach (Match match in regex.Matches(input))
            {
                var name = match.Groups["name"].Value;
                var price = decimal.Parse(match.Groups["price"].Value);
                products.Add(new Product(name, price));
            }
        }
        catch (ArgumentException ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(ex.Message);
            Console.ResetColor();
            Environment.Exit(1);
        }

        return products;
    }
}
