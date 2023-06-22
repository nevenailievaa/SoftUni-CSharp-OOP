namespace NeedForSpeed;

public class RaceMotorcycle : Motorcycle
{
    //Constructor
    public RaceMotorcycle(int horsePower, double fuel) : base(horsePower, fuel) { }

    //Properties
    private const double DefaultFuelConsumption = 8;
    public override double FuelConsumption => DefaultFuelConsumption;

    //Methods
    public virtual void Drive(double kilometers)
    {
        Fuel -= kilometers * DefaultFuelConsumption;
    }
}
