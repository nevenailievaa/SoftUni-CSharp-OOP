namespace Shapes;

public class Rectangle : Shape
{
    //Fields
    private double height;
    private double width;

    public Rectangle(double height, double width)
    {
        this.height = height;
        this.width = width;
    }

    //Methods
    public override double CalculateArea()
    {
        return this.height * this.width;
    }

    public override double CalculatePerimeter()
    {
        return this.width * 2 + this.height * 2;
    }
}
