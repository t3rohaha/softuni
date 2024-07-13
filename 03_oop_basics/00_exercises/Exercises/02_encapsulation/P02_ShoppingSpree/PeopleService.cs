using System.Text.RegularExpressions;

namespace Encapsulation.P02_ShoppingSpree;
public class ShoppingService
{
    private readonly IEnumerable<Person> _people;
    private readonly IEnumerable<Product> _products;

    public ShoppingService(string people, string products)
    {
        _people = ParsePeople(people);
        _products = ParseProducts(products);
    }

    public IReadOnlyCollection<Person> People { get => _people.ToArray(); }
    public IReadOnlyCollection<Product> Products { get => _products.ToArray(); }

    public bool Shop(string personName, string productName)
    {
        var person = _people.FirstOrDefault(x => x.Name == personName);

        if (person == null)
            throw new ArgumentException($"{personName} not found!");

        var product = _products.FirstOrDefault(x => x.Name == productName);

        if (product == null)
            throw new ArgumentException($"{productName} not found!");

        var success = person.BuyProduct(product);

        return success;
    }

    private IEnumerable<Person> ParsePeople(string input)
    {
        if (!IsValid(input))
            throw new ArgumentException("Invalid people format!");

        var args = input.Split(['=', ';']);

        var people = new List<Person>();

        for (var i = 0; i < args.Length; i+=2)
            people.Add(new Person(args[i], decimal.Parse(args[i+1])));

        return people;
    }

    private IEnumerable<Product> ParseProducts(string input)
    {
        if (!IsValid(input))
            throw new ArgumentException("Invalid products format!");

        var args = input.Split(['=', ';']);

        var products = new List<Product>();

        for (var i = 0; i < args.Length; i+=2)
            products.Add(new Product(args[i], decimal.Parse(args[i+1])));

        return products;
    }

    private bool IsValid(string input)
    {
        var pattern = @"^[A-Za-z]{2,}=\d+(\.\d+)?(;[A-Za-z]{2,}=\d+(\.\d+)?)*$";

        var regex = new Regex(pattern);

        return regex.Match(input).Success;
    }
}