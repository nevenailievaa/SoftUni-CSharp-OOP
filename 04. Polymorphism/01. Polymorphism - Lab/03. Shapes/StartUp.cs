namespace Shapes;

public class StartUp
{
    public static void Main()
    {
        Shape circle = new Circle(5);
        Shape rectangle = new Rectangle(10, 15);

        Console.WriteLine(circle.Draw());
        Console.WriteLine(rectangle.Draw());
    }
}