namespace GraphicEditor;

class Program
{
    static void Main()
    {
        IShape circle = new Circle();
        IShape rectangle = new Rectangle();
        IShape square = new Square();

        GraphicEditor editor = new GraphicEditor();

        editor.DrawShape(circle);
        editor.DrawShape(rectangle);
        editor.DrawShape(square);
    }
}