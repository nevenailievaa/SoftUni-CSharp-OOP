using WildFarm.Models.Foods;
using WildFarm.Models.Interfaces;

namespace WildFarm.Models.Animals;

public class Dog : Mammal
{
    //Fields
    private const double dogWeightMultiplier = 0.4;

    //Constructor
    public Dog(string name, double weight, string livingRegion) : base(name, weight, livingRegion) { }

    //Properties
    protected override double WeightMultiplier => dogWeightMultiplier;

    protected override IReadOnlyCollection<Type> PreferredFoodTypes
        => new HashSet<Type> { typeof(Meat) };

    //Methods
    public override string ProduceSound() => "Woof!";

    public override string ToString()
    {
        return base.ToString() + $"{Weight}, {LivingRegion}, {FoodEaten}]";
    }
}