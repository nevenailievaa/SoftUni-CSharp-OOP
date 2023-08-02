using Formula1.Models.Contracts;
using Formula1.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Formula1.Repositories;

public class FormulaOneCarRepository : IRepository<IFormulaOneCar>
{
    //Fields
    private List<IFormulaOneCar> cars;

    //Constructor
    public FormulaOneCarRepository()
    {
        cars = new List<IFormulaOneCar>();
    }

    //Properties
    public IReadOnlyCollection<IFormulaOneCar> Models => cars;

    //Methods
    public void Add(IFormulaOneCar model) => cars.Add(model);

    public IFormulaOneCar FindByName(string name) => cars.FirstOrDefault(c => c.Model == name);

    public bool Remove(IFormulaOneCar model) => cars.Remove(model);
}