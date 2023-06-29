namespace PizzaCalories.Models;

public class Pizza
{
    //Fields
    private string name;
    private readonly List<Topping> toppings;

    //Constructor
    public Pizza(string name, Dough dough)
    {
        Name = name;
        Dough = dough;
        toppings = new List<Topping>();
    }

    //Properties
    public string Name
    { 
        get => name; 
        private set
        {
            if (value.Length < 1 || value.Length > 15)
            {
                throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
            }
            name = value;
        }
    }
    public Dough Dough { get; private set; }
    public int Count => toppings.Count;
    public double Calories
    {
        get => Dough.Calories + toppings.Sum(t => t.Calories);
    }

    //Methods
    public void AddTopping(Topping topping)
    {
        if (toppings.Count == 10)
        {
            throw new ArgumentException("Number of toppings should be in range [0..10].");
        }
        toppings.Add(topping);
    }

    public override string ToString()
    {
        return $"{Name} - {Calories:f2} Calories.";
    }
}