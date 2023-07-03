using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals;

public class Mouse : Mammal
{
    //Fields
    private const double mouseWeightMultiplier = 0.1;

    //Constructor
    public Mouse(string name, double weight, string livingRegion) : base(name, weight, livingRegion) { }

    //Properties
    protected override double WeightMultiplier => mouseWeightMultiplier;

    protected override IReadOnlyCollection<Type> PreferredFoodTypes
        => new HashSet<Type> { typeof(Fruit), typeof(Vegetable) };

    //Methods
    public override string ProduceSound() => "Squeak";

    public override string ToString()
    {
        return base.ToString() + $"{Weight}, {LivingRegion}, {FoodEaten}]";
    }
}