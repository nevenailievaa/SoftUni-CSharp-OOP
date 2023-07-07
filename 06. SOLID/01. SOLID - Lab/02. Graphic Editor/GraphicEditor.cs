using System;

namespace GraphicEditor;

public class GraphicEditor
{
    public void DrawShape(IShape shape)
    {
        shape.Draw();
    }
}
