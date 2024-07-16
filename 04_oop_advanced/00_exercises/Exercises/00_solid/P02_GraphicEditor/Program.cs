using SOLID.P02_GraphicEditor.Models;

namespace SOLID.P02_GraphicEditor;
public class Program
{
    public static void Main()
    {
        var circle = new Circle();
        var rectangle = new Rectangle();
        var square = new Square();

        var editor = new GraphicEditor();
        editor.DrawShape(circle);
        editor.DrawShape(rectangle);
        editor.DrawShape(square);
    }
}