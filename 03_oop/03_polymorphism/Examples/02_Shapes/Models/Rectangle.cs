namespace Shapes.Models;

public class Rectangle : Shape
{
    private double _width;
    private double _height;

    public Rectangle(double width, double height)
    {
        _width = width;
        _height = height;
    }

    public override double Area() => _width * _height;

    public override double Perimeter() => 2 * _width + 2 * _height;
}
