using RobotService.Core.Contracts;
using RobotService.Models;
using RobotService.Models.Contracts;
using RobotService.Repositories;
using RobotService.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace RobotService.Core;

public class Controller : IController
{
    //Fields
    private readonly SupplementRepository supplements;
    private readonly RobotRepository robots;

    //Constructor
    public Controller()
    {
        supplements = new SupplementRepository();
        robots = new RobotRepository();
    }

    //Methods
    public string CreateRobot(string model, string typeName)
    {
        IRobot robot;

        if (typeName == "IndustrialAssistant")
        {
            robot = new IndustrialAssistant(model);
        }
        else if (typeName == "DomesticAssistant")
        {
            robot = new DomesticAssistant(model);
        }
        else
        {
            return string.Format(OutputMessages.RobotCannotBeCreated, typeName);
        }

        robots.AddNew(robot);
        return string.Format(OutputMessages.RobotCreatedSuccessfully, typeName, model);
    }

    public string CreateSupplement(string typeName)
    {
        ISupplement supplement;

        if (typeName == "SpecializedArm")
        {
            supplement = new SpecializedArm();
        }
        else if (typeName == "LaserRadar")
        {
            supplement = new LaserRadar();
        }
        else
        {
            return string.Format(OutputMessages.SupplementCannotBeCreated, typeName);
        }

        supplements.AddNew(supplement);
        return string.Format(OutputMessages.SupplementCreatedSuccessfully, typeName);
    }

    public string PerformService(string serviceName, int intefaceStandard, int totalPowerNeeded)
    {
        //Finding The Robots
        var selectedRobots = robots.Models()
            .Where(r => r.InterfaceStandards.Any(i => i == intefaceStandard))
            .OrderByDescending(r => r.BatteryLevel);

        if (!selectedRobots.Any())
        {
            return String.Format(OutputMessages.UnableToPerform, intefaceStandard);
        }

        //Battery
        int batteryLevelSum = Enumerable.Sum<IRobot>(selectedRobots, (Func<IRobot, int>)(r => r.BatteryLevel));

        if (batteryLevelSum < totalPowerNeeded)
        {
            return String.Format(OutputMessages.MorePowerNeeded, serviceName, (totalPowerNeeded-batteryLevelSum));
        }
        else
        {
            int robotsCount = 0;

            foreach (var robot in selectedRobots)
            {
                robotsCount++;

                if (robot.BatteryLevel >= totalPowerNeeded)
                {
                    robot.ExecuteService(totalPowerNeeded);
                    break;
                }
                else
                {
                    totalPowerNeeded -= robot.BatteryLevel;
                    robot.ExecuteService(robot.BatteryLevel);
                }
            }

            return String.Format(OutputMessages.PerformedSuccessfully, serviceName, robotsCount);
        }
    }

    public string Report()
    {
        var robotsSorted = robots.Models()
            .OrderByDescending(r => r.BatteryLevel)
            .ThenBy(r => r.BatteryCapacity);

        StringBuilder sb = new StringBuilder();

        foreach (var robot in robotsSorted)
        {
            sb.AppendLine(robot.ToString());
        }

        return sb.ToString().TrimEnd();
    }

    public string RobotRecovery(string model, int minutes)
    {
        var selectedRobots = robots.Models()
            .Where(r => r.Model == model)
            .Where(r => r.BatteryLevel < r.BatteryCapacity / 2);

        int robotsFed = 0;

        foreach (var robot in selectedRobots)
        {
            robot.Eating(minutes);
            robotsFed++;
        }

        return String.Format(OutputMessages.RobotsFed, robotsFed);
    }

    public string UpgradeRobot(string model, string supplementTypeName)
    {
        //Filters
        ISupplement supplement = supplements.Models().FirstOrDefault(s => s.GetType().Name == supplementTypeName);

        var selectedModels = robots.Models().Where(r => r.Model == model);

        var stillNotUpgraded = selectedModels.Where(r => r.InterfaceStandards.All(s => s != supplement.InterfaceStandard));

        //Robot
        IRobot robotForUpgrade = stillNotUpgraded.FirstOrDefault();

        if (robotForUpgrade == null)
        {
            return String.Format(OutputMessages.AllModelsUpgraded, model);
        }
        else
        {
            robotForUpgrade.InstallSupplement(supplement);
            supplements.RemoveByName(supplementTypeName);
        }

        return string.Format(OutputMessages.UpgradeSuccessful, model, supplementTypeName);
    }
}