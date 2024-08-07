namespace Encapsulation.P03_PizzaCalories;

public class Topping
{
    private const decimal BASE_CAL = 2;     /* Per Gram */
    private const decimal MIN_WEIGHT = 0;   /* In Gram */
    private const decimal MAX_WEIGHT = 50;  /* In Gram */
    private static readonly Dictionary<string, decimal> _types = new ()
    {
        { "Meat", 1.2m },
        { "Veggies", 0.8m },
        { "Cheese", 1.1m },
        { "Sauce", 0.9m },
    };
    private string _type = "";
    private decimal _weight;                /* In Gram */
    public Topping(string type, decimal weight)
    {
        SetType(type);
        SetWeight(weight);
    }

    public decimal TotalCalories => BASE_CAL * _types[_type] * _weight;

    private void SetType(string type)
    {
        if (!_types.ContainsKey(type))
            throw new Exception($"Cannot place {type} on top of your pizza.");
        _type = type;
    }

    private void SetWeight(decimal weight)
    {
        if (weight < MIN_WEIGHT || weight > MAX_WEIGHT)
            throw new Exception($"{_type} weight should be in the range [{MIN_WEIGHT}..{MAX_WEIGHT}].");
        _weight = weight;
    }
}
