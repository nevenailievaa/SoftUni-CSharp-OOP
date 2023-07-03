using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals;

public class Tiger : Feline
{
    //Fields
    private const double tigerWeightMultiplier = 1;

    //Constructor
    public Tiger(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed) { }

    //Properties
    protected override double WeightMultiplier => tigerWeightMultiplier;

    protected override IReadOnlyCollection<Type> PreferredFoodTypes
        => new HashSet<Type> { typeof(Meat) };

    //Methods
    public override string ProduceSound() => "ROAR!!!";
}