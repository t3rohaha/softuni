namespace PizzaCalories;

public class Pizza
{
    private string _name = "";
    private Dough _dough;
    private ICollection<Topping> _toppings = new List<Topping>();
    public Pizza(string name, Dough dough)
    {
        SetName(name);
        _dough = dough;
    }

    public string Name => _name;
    public int ToppingsCount => _toppings.Count;
    public decimal TotalCalories => _dough.TotalCalories + _toppings.Sum(x => x.TotalCalories);

    private void SetName(string name)
    {
        if (string.IsNullOrEmpty(name) || name.Length < 1 || name.Length > 15)
            throw new Exception($"Pizza name should be between 1 and 15 symbols.");
        _name = name;
    }

    public void AddTopping(Topping topping)
    {
        if (_toppings.Count == 10)
            throw new Exception("Number of toppings should be in range [0..10].");
        _toppings.Add(topping);
    }

    public override string ToString()
    {
        return $"Pizza {_name} - {TotalCalories:0.00} Calories.";
    }
}