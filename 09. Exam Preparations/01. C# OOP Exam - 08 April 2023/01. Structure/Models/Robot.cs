using RobotService.Models.Contracts;
using System.Collections.Generic;
using RobotService.Utilities.Messages;
using System;
using System.Text;

namespace RobotService.Models;

public abstract class Robot : IRobot
{
    //Fields
    private string model;
    private int batteryCapacity;
    private int batteryLevel;
    private int convertionCapacityIndex;
    private List<int> interfaceStandards;

    //Constructor
    protected Robot(string model, int batteryCapacity, int convertionCapacityIndex)
    {
        Model = model;
        BatteryCapacity = batteryCapacity;
        this.batteryLevel = batteryCapacity;
        this.convertionCapacityIndex = convertionCapacityIndex;
        this.interfaceStandards = new List<int>();
    }

    //Properties
    public string Model
    {
        get => model;
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(ExceptionMessages.ModelNullOrWhitespace);
            }
            model = value;
        }
    }

    public int BatteryCapacity
    {
        get => batteryCapacity;
        private set
        {
            if (value < 0)
            {
                throw new ArgumentException(ExceptionMessages.BatteryCapacityBelowZero);
            }
            batteryCapacity = value;
        }
    }

    public int BatteryLevel => batteryLevel;

    public int ConvertionCapacityIndex => convertionCapacityIndex;

    public IReadOnlyCollection<int> InterfaceStandards => interfaceStandards;


    //Methods
    public void Eating(int minutes)
    {
        int energyProduced = ConvertionCapacityIndex * minutes;

        if (BatteryLevel + energyProduced >= BatteryCapacity)
        {
            batteryLevel = BatteryCapacity;
        }
        else
        {
            batteryLevel += energyProduced;
        }
    }

    public bool ExecuteService(int consumedEnergy)
    {
        if (batteryLevel >= consumedEnergy)
        {
            batteryLevel -= consumedEnergy;
            return true;
        }
        return false;
    }

    public void InstallSupplement(ISupplement supplement)
    {
        interfaceStandards.Add(supplement.InterfaceStandard);
        batteryCapacity -= supplement.BatteryUsage;
        batteryLevel -= supplement.BatteryUsage;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine($"{this.GetType().Name} {Model}:");
        sb.AppendLine($"--Maximum battery capacity: {BatteryCapacity}");
        sb.AppendLine($"--Current battery level: {BatteryLevel}");

        if (interfaceStandards.Count > 0)
        {
            sb.AppendLine($"--Supplements installed: {String.Join(" ", interfaceStandards)}");
        }
        else
        {
            sb.AppendLine($"--Supplements installed: none");
        }

        return sb.ToString().TrimEnd();
    }
}