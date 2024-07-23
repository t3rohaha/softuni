using SOLID.P02_GraphicEditor.Interfaces;

namespace SOLID.P02_GraphicEditor.Models;
public class Circle : IShape
{
    public void Draw()
    {
        Console.WriteLine("I'm a circle.");
    }
}