namespace Restaurant;

public class Dessert : Food
{
    //Constructor
    public Dessert(string name, decimal price, double grams, double calories) : base(name, price, grams)
    {
        Calories = calories;
    }

    //Properties
    public double Calories { get; private set; }
}
