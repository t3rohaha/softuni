namespace Shapes.Models;

public abstract class Shape
{
    public abstract double Perimeter();
    public abstract double Area();

    public virtual string Draw()
    {
        return $"Drawing {GetType().Name}";
    }
}
