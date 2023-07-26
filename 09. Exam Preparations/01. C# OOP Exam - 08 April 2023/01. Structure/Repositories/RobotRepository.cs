using RobotService.Models.Contracts;
using RobotService.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace RobotService.Repositories;

public class RobotRepository : IRepository<IRobot>
{
    //Fields
    private readonly List<IRobot> robots;

    //Methods
    public void AddNew(IRobot model)
    {
        robots.Add(model);
    }

    public IRobot FindByStandard(int interfaceStandard) => robots.FirstOrDefault(x => x.InterfaceStandards.Any(y => y == interfaceStandard));

    public IReadOnlyCollection<IRobot> Models() => robots;

    public bool RemoveByName(string typeName) => robots.Remove(robots.FirstOrDefault(r => r.GetType().Name == typeName));
}
