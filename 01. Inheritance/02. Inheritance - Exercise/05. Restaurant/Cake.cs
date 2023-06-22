namespace Restaurant;
public class Cake : Dessert
{
    //Constants
    private const double CakeGrams = 250;
    private const double CakeCalories = 1000;
    private const decimal CakePrice = 5m;

    //Constructor
    public Cake(string name) : base(name, CakePrice, CakeGrams, CakeCalories){}
}
