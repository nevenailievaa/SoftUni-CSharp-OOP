using FoodShortage.Models.Interfaces;
namespace FoodShortage.Models;

public class Pet : IBirthable
{
    //Constructor
    public Pet(string name, string birthdate)
    {
        Name = name;
        Birthdate = birthdate;
    }

    //Properties
    public string Name { get; private set; }
    public string Birthdate { get; private set; }
}
