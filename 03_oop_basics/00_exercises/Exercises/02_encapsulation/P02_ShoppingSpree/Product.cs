namespace Encapsulation.P02_ShoppingSpree;
public class Product
{
    private string _name = "";
    private decimal _price;

    public Product(string name, decimal price)
    {
        Name = name;
        Price = price;
    }

    public string Name { get => _name; init => SetName(value); }

    public decimal Price { get => _price; init => SetPrice(value); }

    private void SetName(string value)
    {
        if (string.IsNullOrEmpty(value))
            throw new ArgumentException("Name cannot be empty!");
        else _name = value;
    }

    private void SetPrice(decimal value)
    {
        if (value <= 0)
            throw new ArgumentException("Price cannot be zero or negative!");
        else _price = value;
    }
}