using System.Security.Cryptography.X509Certificates;

namespace Shapes;

public abstract class Shape
{
    //Methods
    public abstract double CalculatePerimeter();
    public abstract double CalculateArea();
    public virtual string Draw()
    {
        return $"Drawing {this.GetType().Name}";
    }
}
