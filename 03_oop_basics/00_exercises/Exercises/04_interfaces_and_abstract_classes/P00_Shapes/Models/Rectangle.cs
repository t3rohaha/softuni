using InterfacesAndAbstractClasses.P00_Shapes.Interfaces;

namespace InterfacesAndAbstractClasses.P00_Shapes.Models;
public class Rectangle : IDrawable
{
    private int _width;
    private int _height;

    public Rectangle(int width, int height)
    {
        _width = width;
        _height = height;
    }

    public void Draw()
    {
        Console.WriteLine($"Drawing rectangle (width: {_width}, height: {_height})");
    }
}