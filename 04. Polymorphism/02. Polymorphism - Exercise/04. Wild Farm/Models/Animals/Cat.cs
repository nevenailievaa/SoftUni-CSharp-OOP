using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals;

public class Cat : Feline
{
    //Fields
    private const double catWeightMultiplier = 0.3;

    //Constructor
    public Cat(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed) { }

    //Properties
    protected override double WeightMultiplier => catWeightMultiplier;

    protected override IReadOnlyCollection<Type> PreferredFoodTypes
        => new HashSet<Type> { typeof(Meat), typeof(Vegetable) };

    //Methods
    public override string ProduceSound() => "Meow";
}