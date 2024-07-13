using Abstraction.P01_Shapes.Interfaces;

namespace Abstraction.P01_Shapes.Models;
public class Circle : IDrawable
{
    private int _radius;

    public Circle(int radius)
    {
        _radius = radius;
    }

    // Copy-Pasted algorithm for drawing a circle.
    public void Draw()
    {
        double rIn = _radius - 0.4;
        double rOut = _radius + 0.4;
        for (double y = _radius; y >= -_radius; --y)
        {
            for (double x = -_radius; x < rOut; x += 0.5)
            {
                double value = x * x + y * y;

                if (value >= rIn * rIn && value <= rOut * rOut)
                    Console.Write("*");
                else
                    Console.Write(" ");
            }
            Console.WriteLine();
        }
    }
}
