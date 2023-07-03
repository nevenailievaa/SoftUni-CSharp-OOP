using WildFarm.Models.Foods;
using WildFarm.Models.Interfaces;

namespace WildFarm.Models.Animals;

public class Owl : Bird
{
    //Fields
    private const double owlWeightMultiplier = 0.25;

    //Constructor
    public Owl(string name, double weight, double wingSize) : base(name, weight, wingSize) { }

    //Properties
    protected override double WeightMultiplier => owlWeightMultiplier;

    protected override IReadOnlyCollection<Type> PreferredFoodTypes
        => new HashSet<Type> { typeof(Meat) };

    //Methods
    public override string ProduceSound() => "Hoot Hoot";
}