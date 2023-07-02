namespace Vehicles;

public class Truck : IVehicle
{
    //Fields
    private double fuelQuantity;
    private double fuelConsumption;

    //Constructor
    public Truck(double fuelQuantity, double fuelConsumption)
    {
        FuelQuantity = fuelQuantity;
        FuelConsumption = fuelConsumption;
    }

    //Properties
    public double FuelQuantity { get => fuelQuantity; private set => fuelQuantity = value; }
    public double FuelConsumption { get => fuelConsumption; private set => fuelConsumption = value + 1.6; }

    //Methods
    public string Drive(double distance)
    {
        if (FuelQuantity - (distance * FuelConsumption) >= 0)
        {
            FuelQuantity -= distance * FuelConsumption;
            return $"Truck travelled {distance} km";
        }
        return "Truck needs refueling";
    }

    public void Refuel(double fuel)
    {
        FuelQuantity += fuel * 0.95;
    }
}
