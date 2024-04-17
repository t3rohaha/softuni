using Shapes.Models;

namespace Shapes;

public class Program
{
    public static void Main()
    {
        var rectangle = new Rectangle(4, 5);
        var circle = new Circle(10);
        var shapes = new List<Shape>() {rectangle, circle};
        shapes.ForEach(shape =>
        {
            Console.WriteLine(shape.Draw());
            Console.WriteLine($"Perimeter: {shape.Perimeter()}");
            Console.WriteLine($"Area: {shape.Area()}");
        });
    }
}