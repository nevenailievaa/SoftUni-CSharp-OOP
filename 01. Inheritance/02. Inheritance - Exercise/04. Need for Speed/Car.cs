namespace NeedForSpeed;

public class Car : Vehicle
{
    //Constructor
    public Car(int horsePower, double fuel) : base(horsePower, fuel) {}

    //Properties
    private const double DefaultFuelConsumption = 3;
    public override double FuelConsumption => DefaultFuelConsumption;

    //Methods
    public virtual void Drive(double kilometers)
    {
        Fuel -= kilometers * DefaultFuelConsumption;
    }
}
