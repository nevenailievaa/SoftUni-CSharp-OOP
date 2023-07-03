using WildFarm.Models.Foods;
using WildFarm.Models.Interfaces;

namespace WildFarm.Models.Animals;

public class Hen : Bird
{
    //Fields
    private const double henWeightMultiplier = 0.35;

    //Constructor
    public Hen(string name, double weight, double wingSize) : base(name, weight, wingSize) { }

    //Properties
    protected override double WeightMultiplier => henWeightMultiplier;

    protected override IReadOnlyCollection<Type> PreferredFoodTypes
        => new HashSet<Type> { typeof(Meat), typeof(Seeds), typeof(Fruit), typeof(Vegetable) };

    //Methods
    public override string ProduceSound() => "Cluck";
}