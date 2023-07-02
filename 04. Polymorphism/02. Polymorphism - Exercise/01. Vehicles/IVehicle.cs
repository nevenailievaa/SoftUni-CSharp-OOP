namespace Vehicles;

public interface IVehicle
{
    //Properties
    public double FuelQuantity { get;}
    public double FuelConsumption { get;}

    //Methods
    string Drive(double distance);
    void Refuel(double fuel);
}
