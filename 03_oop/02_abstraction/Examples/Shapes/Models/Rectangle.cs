using Shapes.Interfaces;

namespace Shapes.Models;

public class Rectangle : IDrawable
{
    private int _width;
    private int _height;
    
    public Rectangle(int width, int height)
    {
        _width = width;
        _height = height;
    }

    // Copy-Pasted algorithm for drawing a rectangle.
    public void Draw()
    {
        DrawLine(_width, '*', '*');
        for (int i = 1; i < _height - 1; ++i) DrawLine(_width, '*', ' ');
        DrawLine(_width, '*', '*');

    }

    private void DrawLine(int width, char end, char mid)
    {
        Console.Write(end);
        for (int i = 1; i < width - 1; ++i) Console.Write(mid);
        Console.WriteLine(end);
    }
}
