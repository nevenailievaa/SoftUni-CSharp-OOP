using Formula1.Models.Contracts;
using Formula1.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Formula1.Repositories;

public class RaceRepository : IRepository<IRace>
{
    //Fields
    private List<IRace> races;

    //Constructor
    public RaceRepository()
    {
        races= new List<IRace>();
    }

    //Properties
    public IReadOnlyCollection<IRace> Models => races;

    //Methods
    public void Add(IRace model) => races.Add(model);

    public IRace FindByName(string name) => races.FirstOrDefault(r => r.RaceName == name);

    public bool Remove(IRace model) => races.Remove(model);
}