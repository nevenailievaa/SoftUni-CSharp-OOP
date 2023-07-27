using EDriveRent.Models.Contracts;
using EDriveRent.Utilities.Messages;
using System;

namespace EDriveRent.Models;

public abstract class Vehicle : IVehicle
{
    //Fields
    private string brand;
    private string model;
    private readonly double maxMileage;
    private string licensePlateNumber;
    private int batteryLevel;
    private bool isDamaged;

    //Constructor
    public Vehicle(string brand, string model, double maxMileage, string licensePlateNumber)
    {
        this.brand = brand;
        this.model = model;
        this.maxMileage = maxMileage;
        this.licensePlateNumber = licensePlateNumber;
        this.batteryLevel = 100;
        this.isDamaged = false;
    }

    //Properties
    public string Brand
    {
        get => brand;
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(ExceptionMessages.BrandNull);
            }
        }
    }

    public string Model
    {
        get => model;
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(ExceptionMessages.ModelNull);
            }
        }
    }

    public double MaxMileage { get => maxMileage; }

    public string LicensePlateNumber
    {
        get => licensePlateNumber;
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(ExceptionMessages.LicenceNumberRequired);
            }
        }
    }

    public int BatteryLevel { get => batteryLevel; private set => batteryLevel = value; }

    public bool IsDamaged { get => isDamaged; private set => isDamaged = value; }

    //Methods
    public void ChangeStatus()
    {
        if (IsDamaged)
        {
            isDamaged = false;
        }
        else
        {
            isDamaged = true;
        }
    }

    public virtual void Drive(double mileage)
    {
        double percentage = Math.Round((mileage / MaxMileage) * 100);
        batteryLevel -= (int)percentage;

        if (this.GetType().Name == nameof(CargoVan))
        {
            batteryLevel -= 5;
        }
    }

    public void Recharge()
    {
        batteryLevel = 100;
    }

    public override string ToString()
    {
        if (isDamaged == false)
        {
            return $"{Brand} {Model} License plate: {LicensePlateNumber} Battery: {BatteryLevel}% Status: OK";
        }
        else
        {
            return $"{Brand} {Model} License plate: {LicensePlateNumber} Battery: {BatteryLevel}% Status: damaged";
        }
    }
}