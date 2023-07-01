namespace Animals;

public class Animal
{
    //Fields
    private string name;
    private string favouriteFood;

    //Constructor
    public Animal(string name, string favouriteFood)
    {
        this.name = name;
        this.favouriteFood = favouriteFood;
    }

    //Methods
    public virtual string ExplainSelf()
    {
        return $"I am {name} and my favourite food is {favouriteFood}";
    }
}