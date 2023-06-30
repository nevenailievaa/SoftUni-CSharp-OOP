using FoodShortage.Models.Interfaces;
namespace FoodShortage.Models;

public class Citizen : IEnter, IBirthable, IBuyer
{
    //Constructor
    public Citizen(string name, int age, string id, string birthdate)
    {
        Name = name;
        Age = age;
        Id = id;
        Birthdate = birthdate;
    }

    //Properties
    public string Name { get; private set; }
    public int Age { get; private set; }
    public string Id { get; private set; }
    public string Birthdate { get; private set; }
    public int Food { get; private set; } = 0;

    public void BuyFood()
    {
        Food += 10;
    }
}