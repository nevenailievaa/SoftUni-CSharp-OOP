namespace Shapes;

public class Circle : Shape
{
    //Fields
    private double radius;

    public Circle(double radius)
    {
        this.radius = radius;
    }

    //Methods
    public override double CalculateArea()
    {
        return Math.PI * this.radius * this.radius;
    }

    public override double CalculatePerimeter()
    {
        return 2 * Math.PI * radius;
    }
}
