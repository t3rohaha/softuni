using InterfacesAndAbstractClasses.P00_Shapes.Interfaces;

namespace InterfacesAndAbstractClasses.P00_Shapes.Models;
public class Circle : IDrawable
{
    private int _radius;

    public Circle(int radius)
    {
        _radius = radius;
    }

    public void Draw()
    {
        Console.WriteLine($"Drawing circle (radius: {_radius})");
    }
}