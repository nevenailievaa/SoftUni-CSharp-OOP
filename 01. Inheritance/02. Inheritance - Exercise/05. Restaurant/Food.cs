namespace Restaurant;

public class Food : Product
{
    //Constructor
    public Food(string name, decimal price, double grams) : base(name, price)
    {
        Grams = grams;
    }

    //Properties
    public double Grams { get; private set; }
}
