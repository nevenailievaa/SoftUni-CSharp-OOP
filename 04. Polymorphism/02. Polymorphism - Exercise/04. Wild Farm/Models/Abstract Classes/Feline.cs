using WildFarm.Models.Interfaces;

namespace WildFarm.Models.Animals;

public abstract class Feline : Mammal, IFeline
{
    //Constructor
    protected Feline(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion)
    {
        Breed = breed;
    }

    //Properties
    public string Breed { get; private set; }

    //Methods
    public override string ToString()
    {
        return base.ToString() + $"{Breed}, {Weight}, {LivingRegion}, {FoodEaten}]"; ;
    }
}