using RobotService.Models.Contracts;
using RobotService.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace RobotService.Repositories;

public class SupplementRepository : IRepository<ISupplement>
{
    //Fields
    private readonly List<ISupplement> supplements;

    //Constructor
    public SupplementRepository()
    {
        supplements = new List<ISupplement>();
    }

    //Methods
    public void AddNew(ISupplement model)
    {
        supplements.Add(model);
    }

    public ISupplement FindByStandard(int interfaceStandard) => supplements.FirstOrDefault(x => x.InterfaceStandard == interfaceStandard);

    public IReadOnlyCollection<ISupplement> Models() => supplements;

    public bool RemoveByName(string typeName) => supplements.Remove(supplements.FirstOrDefault(s => s.GetType().Name == typeName));
}