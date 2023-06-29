namespace Cars;

public interface ICar
{
    //Properties
    string Model { get; set; }
    string Color { get; set; }

    public string Start();
    public string Stop();
}
