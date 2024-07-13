namespace Encapsulation.P03_PizzaCalories;
public sealed class Dough
{
    private const decimal BASE_CAL = 2;     /* Per Gram */
    private const decimal MIN_WEIGHT = 0;   /* In Gram */
    private const decimal MAX_WEIGHT = 200; /* In Gram */
    private static readonly Dictionary<string, decimal> _types = new ()
    {
        {"White", 1.5m},
        {"Wholegrain", 1m},
    };
    private static readonly Dictionary<string, decimal> _techniques = new ()
    {
        {"Crispy", 0.9m},
        {"Chewy", 1.1m},
        {"Homemade", 1m},
    };
    private string _type = "";
    private string _technique = "";
    private decimal _weight;                /* In Gram */
    public Dough(string flourType, string bakingTechnique, decimal weight)
    {
        SetType(flourType);
        SetBakingTechnique(bakingTechnique);
        SetWeight(weight);
    }

    public decimal TotalCalories => BASE_CAL * _types[_type] * _techniques[_technique] * _weight;

    private void SetType(string type)
    {
        if (!_types.ContainsKey(type))
            throw new Exception("Invalid type of dough.");
        _type = type;
    }

    private void SetBakingTechnique(string technique)
    {
        if (!_techniques.ContainsKey(technique))
            throw new Exception("Invalid baking technique.");
        _technique = technique;
    }

    private void SetWeight(decimal weight)
    {
        if (weight < MIN_WEIGHT || weight > MAX_WEIGHT)
            throw new Exception($"Dough weight should be in the range [{MIN_WEIGHT}..{MAX_WEIGHT}].");
        _weight = weight;
    }
}