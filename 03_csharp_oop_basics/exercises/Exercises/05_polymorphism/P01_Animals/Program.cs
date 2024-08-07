using Polymorphism.P01_Animals.Models;

namespace Polymorphism.P01_Animals;
public class Program
{
    public static void Main()
    {
        var cat = new Cat("Jessy", "Whiskas");
        var dog = new Dog("Kaira", "Pedigree");
        var animals = new List<Animal> {cat, dog};
        animals.ForEach(a => Console.WriteLine(a.ExplainSelf()));
    }
}