using WildFarm.Models.Interfaces;

namespace WildFarm.Models.Animals;

public abstract class Animal : IAnimal
{
    //Constructor
    protected Animal(string name, double weight)
    {
        Name = name;
        Weight = weight;
    }

    //Properties
    public string Name { get; private set; }

    public double Weight { get; private set; }

    public int FoodEaten { get; private set; }

    protected abstract double WeightMultiplier { get; }

    protected abstract IReadOnlyCollection<Type> PreferredFoodTypes { get; }

    //Methods
    public void Eat(IFood food)
    {
        if (!PreferredFoodTypes.Any(pf => pf.Name == food.GetType().Name))
        {
            throw new ArgumentException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
        }

        Weight += food.Quantity * WeightMultiplier;
        FoodEaten += food.Quantity;
    }

    public abstract string ProduceSound();

    public override string ToString()
    {
        return $"{GetType().Name} [{Name}, ";
    }
}
