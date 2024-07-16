using SOLID.P02_GraphicEditor.Interfaces;

namespace SOLID.P02_GraphicEditor;
public class GraphicEditor
{
    public void DrawShape(IShape shape)
    {
        shape.Draw();
    }
}