namespace Shapes;

public class Circle : IDrawable
{
    //Fields
    private int radius;

    //Constructor
    public Circle(int radius)
    {
        this.radius = radius;
    }

    //Methods
    public void Draw()
    {
        double rIn = this.radius - 0.4;
        double rOut = this.radius + 0.4;

        for (double y = this.radius; y >= -this.radius; --y)
        {
            for (double x = -this.radius; x < rOut; x += 0.5)
            {
                double value = x * x + y * y;
                if (value >= rIn * rIn && value <= rOut * rOut)
                    Console.Write("*");
                else
                    Console.Write(" ");
            }
            Console.WriteLine();
        }
    }
}