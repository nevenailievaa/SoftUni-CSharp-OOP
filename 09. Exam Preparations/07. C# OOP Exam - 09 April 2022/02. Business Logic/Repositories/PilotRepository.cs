using Formula1.Models.Contracts;
using Formula1.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formula1.Repositories;

public class PilotRepository : IRepository<IPilot>
{
    //Fields
    private List<IPilot> pilots;

    //Constructor
    public PilotRepository()
    {
        pilots= new List<IPilot>();
    }

    //Properties
    public IReadOnlyCollection<IPilot> Models => pilots;

    //Methods
    public void Add(IPilot model) => pilots.Add(model);

    public IPilot FindByName(string name) => pilots.FirstOrDefault(c => c.FullName == name);

    public bool Remove(IPilot model) => pilots.Remove(model);
}