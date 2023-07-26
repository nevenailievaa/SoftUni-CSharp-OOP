using RobotService.Models.Contracts;
using System;

namespace RobotService.Models;

public abstract class Supplement : ISupplement
{
    //Fields
    private int interfaceStandard;
    private int batteryUsage;

    //Constructor
    public Supplement(int interfaceStandard, int batteryUsage)
    {
        InterfaceStandard = interfaceStandard;
        BatteryUsage = batteryUsage;
    }

    //Properties
    public int InterfaceStandard
    {
        get => interfaceStandard;
        private set => interfaceStandard = value;
    }

    public int BatteryUsage
    {
        get => batteryUsage;
        private set => batteryUsage = value;
    }
}