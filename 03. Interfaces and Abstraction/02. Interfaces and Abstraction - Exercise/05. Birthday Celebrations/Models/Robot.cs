using BirthdayCelebrations.Models.Interfaces;

namespace BirthdayCelebrations.Models;

public class Robot : IEnter
{
    //Constructor
    public Robot(string model, string id)
    {
        Model = model;
        Id = id;
    }

    //Properties
    public string Model { get; private set; }
    public string Id { get; private set; }
}