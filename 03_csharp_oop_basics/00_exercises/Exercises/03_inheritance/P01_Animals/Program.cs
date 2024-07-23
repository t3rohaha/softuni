using Inheritance.P01_Animals.Models;

namespace Inheritance.P01_Animals;
public class Program
{
    public static void Main()
    {
        var animals = new List<Animal>();

        while (true)
        {
            string animalType = Console.ReadLine()!;

            if (animalType == "Beast!") break;

            string[] arguments = Console.ReadLine()!.Split(' ');

            string name = arguments[0];
            int age = int.Parse(arguments[1]);
            string gender = arguments[2];

            if (string.IsNullOrEmpty(name) ||
                string.IsNullOrEmpty(gender) ||
                age < 0)
            {
                Console.WriteLine("Invalid input!");
                continue;
            }
            
            switch (animalType)
            {
                case "Dog": animals.Add(new Dog(name, age, gender)); break; 
                case "Frog": animals.Add(new Frog(name, age, gender)); break;
                case "Cat": animals.Add(new Cat(name, age, gender)); break;
                case "Kitten": animals.Add(new Kitten(name, age)); break;
                case "Tomcat": animals.Add(new Tomcat(name, age)); break;
            }
        }
        
        Console.WriteLine();
        foreach (Animal a in animals)
            Console.WriteLine(a.ToString());
    }
}
