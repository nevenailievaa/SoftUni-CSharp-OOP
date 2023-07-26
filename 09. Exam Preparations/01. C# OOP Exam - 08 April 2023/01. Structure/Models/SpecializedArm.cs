namespace RobotService.Models;

internal class SpecializedArm : Supplement
{
    //Fields
    private const int interfaceStandard = 10045;
    private const int batteryUsage = 10000;

    //Constructor
    public SpecializedArm() : base(interfaceStandard, batteryUsage){}
}