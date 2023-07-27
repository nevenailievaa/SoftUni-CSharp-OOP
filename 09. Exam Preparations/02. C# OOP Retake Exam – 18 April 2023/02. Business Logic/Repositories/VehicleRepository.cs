using EDriveRent.Models;
using EDriveRent.Models.Contracts;
using EDriveRent.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace EDriveRent.Repositories;

public class VehicleRepository : IRepository<IVehicle>
{
    //Fields
    private readonly List<IVehicle> vehicles;

    //Constructor
    public VehicleRepository()
    {
        vehicles = new List<IVehicle>();
    }

    //Methods
    public void AddModel(IVehicle model)
    {
        vehicles.Add(model);
    }

    public IVehicle FindById(string identifier) => vehicles.FirstOrDefault(v => v.LicensePlateNumber == identifier);

    public IReadOnlyCollection<IVehicle> GetAll() => vehicles;

    public bool RemoveById(string identifier) => vehicles.Remove(vehicles.FirstOrDefault(v => v.LicensePlateNumber == identifier));
}