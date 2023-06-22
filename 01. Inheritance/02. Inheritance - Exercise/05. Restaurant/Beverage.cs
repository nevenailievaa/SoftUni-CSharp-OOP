namespace Restaurant;

public class Beverage : Product
{
    //Constructor
    public Beverage(string name, decimal price, double mililiters) : base(name, price)
    {
        Mililiters = mililiters;
    }

    //Properties
    public double Mililiters { get; private set; }
}
