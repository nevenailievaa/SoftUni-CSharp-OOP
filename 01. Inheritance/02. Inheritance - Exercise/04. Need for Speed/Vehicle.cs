namespace NeedForSpeed;

public class Vehicle
{
    //Constructor
    public Vehicle(int horsePower, double fuel)
    {
        HorsePower = horsePower;
        Fuel = fuel;
    }

    //Properties
    private const double DefaultFuelConsumption = 1.25;
    public virtual double FuelConsumption { get { return DefaultFuelConsumption; }}
    public double Fuel { get; set; }
    public int HorsePower { get; set; }

    //Methods
    public virtual void Drive(double kilometers)
    {
        Fuel -= kilometers * DefaultFuelConsumption;
    }
}
