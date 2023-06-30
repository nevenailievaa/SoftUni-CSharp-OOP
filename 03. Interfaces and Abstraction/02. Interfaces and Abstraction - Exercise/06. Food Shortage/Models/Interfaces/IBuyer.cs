namespace FoodShortage.Models.Interfaces;

public interface IBuyer
{
    public string Name { get; }
    public int Food { get; }
    void BuyFood();
}
