namespace Polymorphism.P02_Shapes.Models;
public class Circle : Shape
{
    private double _radius;

    public Circle(double radius)
    {
        _radius = radius;
    }

    public override double Area() => Math.PI * Math.Pow(_radius, 2);
    public override double Perimeter() => 2 * Math.PI * _radius;

}