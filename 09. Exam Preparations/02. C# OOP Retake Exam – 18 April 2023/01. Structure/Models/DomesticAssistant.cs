namespace RobotService.Models;

public class DomesticAssistant : Robot
{
    //Fields
    private const int batteryCapacity = 20000;
    private const int convertionCapacityIndex = 2000;

    //Constructor
    public DomesticAssistant(string model) : base(model, batteryCapacity, convertionCapacityIndex) { }
}
