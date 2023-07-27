using EDriveRent.Core.Contracts;
using EDriveRent.Models;
using EDriveRent.Models.Contracts;
using EDriveRent.Repositories;
using EDriveRent.Utilities.Messages;
using System;
using System.Linq;
using System.Text;

namespace EDriveRent.Core;

public class Controller : IController
{
    //Fields
    private UserRepository users;
    private VehicleRepository vehicles;
    private RouteRepository routes;

    //Constructor
    public Controller()
    {
        users = new UserRepository();
        vehicles = new VehicleRepository();
        routes = new RouteRepository();
    }

    //Methods
    public string AllowRoute(string startPoint, string endPoint, double length)
    {
        if (routes.GetAll().Any(r => r.StartPoint == startPoint && r.EndPoint == endPoint && r.Length == length))
        {
            return String.Format(OutputMessages.RouteExisting, startPoint, endPoint, length);
        }
        else if (routes.GetAll().Any(r => r.StartPoint == startPoint && r.EndPoint == endPoint && r.Length < length))
        {
            return String.Format(OutputMessages.RouteIsTooLong, startPoint, endPoint);
        }
        else
        {
            Route route = new Route(startPoint, endPoint, length, routes.GetAll().Count + 1);
            IRoute sameRouteButLonger = routes.GetAll().FirstOrDefault(r => r.StartPoint == startPoint && r.EndPoint == endPoint && r.Length > length);

            if (sameRouteButLonger != default)
            {
                sameRouteButLonger.LockRoute();
            }

            routes.AddModel(route);
            return String.Format(OutputMessages.NewRouteAdded, startPoint, endPoint, length);
        }
    }

    public string MakeTrip(string drivingLicenseNumber, string licensePlateNumber, string routeId, bool isAccidentHappened)
    {
        IUser currentUser = users.FindById(drivingLicenseNumber);
        IVehicle currentVehicle = vehicles.FindById(licensePlateNumber);
        IRoute currentRoute = routes.FindById(routeId);

        if (currentUser.IsBlocked)
        {
            return String.Format(OutputMessages.UserBlocked, drivingLicenseNumber);
        }
        else if (currentVehicle.IsDamaged)
        {
            return String.Format(OutputMessages.VehicleDamaged, licensePlateNumber);
        }
        else if (currentRoute.IsLocked)
        {
            return String.Format(OutputMessages.RouteLocked, routeId);
        }

        currentVehicle.Drive(currentRoute.Length);

        if (isAccidentHappened)
        {
            currentVehicle.ChangeStatus();
            currentUser.DecreaseRating();

            return $"{currentVehicle.Brand} {currentVehicle.Model} License plate: {currentVehicle.LicensePlateNumber} Battery: {currentVehicle.BatteryLevel}% Status: damaged";
        }
        else
        {
            currentUser.IncreaseRating();
        }

        return $"{currentVehicle.Brand} {currentVehicle.Model} License plate: {currentVehicle.LicensePlateNumber} Battery: {currentVehicle.BatteryLevel}% Status: OK";
    }

    public string RegisterUser(string firstName, string lastName, string drivingLicenseNumber)
    {
        if (users.GetAll().Any(u => u.DrivingLicenseNumber == drivingLicenseNumber))
        {
            return String.Format(OutputMessages.UserWithSameLicenseAlreadyAdded, drivingLicenseNumber);
        }
        else
        {
            User user = new User(firstName, lastName, drivingLicenseNumber);
            users.AddModel(user);
            return String.Format(OutputMessages.UserSuccessfullyAdded, firstName, lastName, drivingLicenseNumber);
        }
    }

    public string RepairVehicles(int count)
    {
        var damagedVehicles = vehicles.GetAll().Where(v => v.IsDamaged).OrderBy(v => v.Brand).ThenBy(v => v.Model);

        if (damagedVehicles.Count() <= count)
        {
            count = damagedVehicles.Count();
            foreach (var vehicle in damagedVehicles)
            {
                vehicle.ChangeStatus();
                vehicle.Recharge();
            }
        }
        else
        {
            var selectedVehicles = damagedVehicles.ToArray().Take(count);

            foreach (var vehicle in selectedVehicles)
            {
                vehicle.ChangeStatus();
                vehicle.Recharge();
            }
        }

        return String.Format(OutputMessages.RepairedVehicles, count);
    }

    public string UploadVehicle(string vehicleType, string brand, string model, string licensePlateNumber)
    {
        if (vehicleType != "CargoVan" && vehicleType != "PassengerCar")
        {
            return String.Format(OutputMessages.VehicleTypeNotAccessible, vehicleType);
        }
        else if (vehicles.GetAll().Any(v => v.LicensePlateNumber == licensePlateNumber))
        {
            return String.Format(OutputMessages.LicensePlateExists, licensePlateNumber);
        }
        else
        {
            IVehicle vehicle;

            if (vehicleType == "CargoVan")
            {
                vehicle = new CargoVan(brand, model, licensePlateNumber);
                vehicles.AddModel(vehicle);
            }
            else if (vehicleType == "PassengerCar")
            {
                vehicle = new PassengerCar(brand, model, licensePlateNumber);
                vehicles.AddModel(vehicle);
            }

            return String.Format(OutputMessages.VehicleAddedSuccessfully, brand, model, licensePlateNumber);
        }
    }

    public string UsersReport()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("*** E-Drive-Rent ***");

        foreach (var user in users.GetAll()
            .OrderByDescending(u => u.Rating)
            .ThenBy(u => u.LastName)
            .ThenBy(u => u.FirstName))
        {
            sb.AppendLine(user.ToString());
        }

        return sb.ToString().TrimEnd();
    }
}