namespace Cars;

public class Tesla : IElectricCar
{
    //Constructor
    public Tesla(string model, string color, int battery)
    {
        Model = model;
        Color = color;
        Battery=battery;
    }

    //Properties
    public string Model { get; set; }
    public string Color { get; set; }
    public int Battery { get; set; }

    //Methods
    public string Start() => "Engine start";
    public string Stop() => "Breaaak!";

    public override string ToString()
    {
        Console.WriteLine($"{Color} Tesla {Model} with {Battery} Batteries");
        Console.WriteLine(Start());

        return Stop();
    }
}