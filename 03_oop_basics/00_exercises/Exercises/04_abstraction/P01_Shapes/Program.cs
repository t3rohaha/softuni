using Abstraction.P01_Shapes.Interfaces;
using Abstraction.P01_Shapes.Models;

namespace Abstraction.P01_Shapes;
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