namespace NeedForSpeed;

public class SportCar : Car
{
    //Constructor
    public SportCar(int horsePower, double fuel) : base(horsePower, fuel) { }

    //Properties
    private const double DefaultFuelConsumption = 10;
    public override double FuelConsumption => DefaultFuelConsumption;

    //Methods
    public virtual void Drive(double kilometers)
    {
        Fuel -= kilometers * DefaultFuelConsumption;
    }
}
