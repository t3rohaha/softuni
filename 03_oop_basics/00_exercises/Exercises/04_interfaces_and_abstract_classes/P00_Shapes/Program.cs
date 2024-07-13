using InterfacesAndAbstractClasses.P00_Shapes.Interfaces;
using InterfacesAndAbstractClasses.P00_Shapes.Models;

namespace InterfacesAndAbstractClasses.P00_Shapes;
public class Program
{
    public static void Main()
    {
        Console.Write("Enter circle radius: ");
        var radius = int.Parse(Console.ReadLine()!);

        Console.Write("Enter rectangle width: ");
        var width = int.Parse(Console.ReadLine()!);

        Console.Write("Enter rectangle height: ");
        var height = int.Parse(Console.ReadLine()!);

        IDrawable circle = new Circle(radius);
        IDrawable rectangle = new Rectangle(width, height);

        circle.Draw();
        rectangle.Draw();
    }
}