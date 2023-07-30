using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversityCompetition.Models;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Repositories.Contracts;

namespace UniversityCompetition.Repositories;

public class UniversityRepository : IRepository<IUniversity>
{
    //Fields
    private ICollection<IUniversity> universities;

    //Constructor
    public UniversityRepository()
    {
        universities = new List<IUniversity>();
    }

    //Properties
    public IReadOnlyCollection<IUniversity> Models => throw new NotImplementedException();

    //Methods
    public void AddModel(IUniversity model) => universities.Add(model);
    public IUniversity FindById(int id) => universities.FirstOrDefault(u => u.Id == id);

    public IUniversity FindByName(string name) => universities.FirstOrDefault(u => u.Name == name);
}
