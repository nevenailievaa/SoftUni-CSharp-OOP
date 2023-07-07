namespace GraphicEditor;

public class Rectangle : IShape
{
    public void Draw()
    {
        Console.WriteLine($"I'm {this.GetType().Name}");
    }
}
