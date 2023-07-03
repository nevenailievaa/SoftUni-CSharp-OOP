namespace WildFarm.Models.Interfaces;

public interface IAnimal
{
    //Properties
    public string Name { get; }
    public double Weight { get; }
    public int FoodEaten { get; }

    //Methods
    public string ProduceSound();
    public void Eat(IFood food);
}
