using SOLID.P02_GraphicEditor.Interfaces;

namespace SOLID.P02_GraphicEditor.Models;
public class Rectangle : IShape
{
    public void Draw()
    {
        Console.WriteLine("I'm a rectangle.");
    }
}