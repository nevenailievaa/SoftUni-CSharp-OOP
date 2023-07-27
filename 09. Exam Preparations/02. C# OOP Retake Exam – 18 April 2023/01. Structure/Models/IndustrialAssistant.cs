namespace RobotService.Models;

public class IndustrialAssistant : Robot
{
    //Fields
    private const int batteryCapacity = 40000;
    private const int convertionCapacityIndex = 5000;

    //Constructor
    public IndustrialAssistant(string model) : base(model, batteryCapacity, convertionCapacityIndex) { }
}
