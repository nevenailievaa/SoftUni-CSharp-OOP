using System.Runtime.CompilerServices;

namespace Restaurant;

public class Fish : MainDish
{
    //Constants
    private const double FishGrams = 22;

    //Constructor
    public Fish(string name, decimal price) : base(name, price, FishGrams) {}
}
