namespace Polymorphism.P01_Animals.Models;
public class Animal
{
    private string _name = "";
    private string _favouriteFood = "";

    public Animal(string name, string favouriteFood)
    {
        _name = name;
        _favouriteFood = favouriteFood;
    }

    public virtual string ExplainSelf()
    {
        return $"I am {_name} and my fovourite food is {_favouriteFood}";
    }
}
