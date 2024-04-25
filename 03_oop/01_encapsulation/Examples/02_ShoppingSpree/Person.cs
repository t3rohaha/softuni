namespace ShoppingSpree;

public class Person
{
    private string _name = "";
    private decimal _money;
    private List<Product> _products;

    public Person(string name, decimal money)
    {
        Name = name;
        Money = money;
        _products = new List<Product>();
    }

    public string Name { get => _name; init => SetName(value); }

    public decimal Money { get => _money; private set => SetMoney(value); }

    public IReadOnlyCollection<Product> Products { get => _products; }

    public bool BuyProduct(Product product)
    {
        if (Money < product.Price) return false;
        
        Money -= product.Price;
        _products.Add(product);

        return true;
    }

    public override string ToString()
    {
        return Products.Count == 0
            ? $"{Name} - Nothing bought"
            : $"{Name} - {string.Join(", ", Products.Select(x => x.Name))}";
    }

    private void SetName(string value)
    {
        if (string.IsNullOrEmpty(value))
            throw new ArgumentException("Name cannot be empty!");
        else _name = value;
    }

    private void SetMoney(decimal value)
    {
        if (value < 0)
            throw new ArgumentException("Money cannot be negative!");
        else _money = value;
    }
}