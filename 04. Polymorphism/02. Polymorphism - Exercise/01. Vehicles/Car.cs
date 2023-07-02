namespace Vehicles;

public class Car : IVehicle
{
    //Fields
    private double fuelQuantity;
    private double fuelConsumption;

    //Constructor
    public Car(double fuelQuantity, double fuelConsumption)
    {
        FuelQuantity = fuelQuantity;
        FuelConsumption = fuelConsumption;
    }

    //Properties
    public double FuelQuantity { get => fuelQuantity; private set => fuelQuantity = value; }
    public double FuelConsumption { get => fuelConsumption; private set => fuelConsumption = value + 0.9; }

    //Methods
    public string Drive(double distance)
    {
        if (FuelQuantity - (distance * FuelConsumption) >= 0)
        {
            FuelQuantity -= distance * FuelConsumption;
            return $"Car travelled {distance} km";
        }
        return "Car needs refueling";
    }

    public void Refuel(double fuel)
    {
        FuelQuantity += fuel;
    }
}
