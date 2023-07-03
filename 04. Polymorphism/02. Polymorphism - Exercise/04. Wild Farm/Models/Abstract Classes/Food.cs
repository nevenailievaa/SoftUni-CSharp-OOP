using WildFarm.Models.Interfaces;

namespace WildFarm.Models.Foods;

public abstract class Food : IFood
{
    //Constructor
    protected Food(int quantity)
    {
        Quantity = quantity;
    }

    //Properties
    public int Quantity {get; private set;}
}
