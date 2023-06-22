namespace Restaurant;

public class Coffee : HotBeverage
{
    //Constants
    private const double CoffeeMililiters = 50;
    private const decimal CoffeePrice = 3.50m;

    //Constructor
    public Coffee(string name, double caffeine) : base(name, CoffeePrice, CoffeeMililiters)
    {
        Caffeine = caffeine;
    }

    //Properties
    public double Caffeine { get; private set; }
}
