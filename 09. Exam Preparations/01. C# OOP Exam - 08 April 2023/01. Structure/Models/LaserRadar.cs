namespace RobotService.Models;

public class LaserRadar : Supplement
{
    //Fields
    private const int interfaceStandard = 20082;
    private const int batteryUsage = 5000;

    //Constructor
    public LaserRadar() : base(interfaceStandard, batteryUsage) { }
}
