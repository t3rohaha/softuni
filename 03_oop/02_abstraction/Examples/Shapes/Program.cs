using Shapes.Interfaces;
using Shapes.Models;

namespace Shapes;

public class Program
{
    public static void Main()
    {
        IDrawable circle = new Circle(3);
        IDrawable rectangle = new Rectangle(5, 4);

        circle.Draw();
        rectangle.Draw();
    }
}