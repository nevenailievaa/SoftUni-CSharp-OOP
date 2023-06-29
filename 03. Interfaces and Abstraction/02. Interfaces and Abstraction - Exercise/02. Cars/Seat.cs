namespace Cars;

public class Seat : ICar
{
    //Constructor
    public Seat(string model, string color)
    {
        Model = model;
        Color = color;
    }

    //Properties
    public string Model { get; set; }
    public string Color { get; set; }

    //Methods
    public string Start() => "Engine start";
    public string Stop() => "Breaaak!";

    public override string ToString()
    {
        Console.WriteLine($"{Color} Seat {Model}");
        Console.WriteLine(Start());

        return Stop();
    }
}
