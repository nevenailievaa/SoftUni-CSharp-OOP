using WildFarm.Models.Interfaces;

namespace WildFarm.Models.Animals;

public abstract class Bird : Animal, IBird
{
    //Constructor
    protected Bird(string name, double weight, double wingSize) : base(name, weight)
    {
        WingSize = wingSize;
    }

    //Properties
    public double WingSize { get; private set; }

    //Methods
    public override string ToString()
    {
        return base.ToString() + $"{WingSize}, {Weight}, {FoodEaten}]";
    }
}