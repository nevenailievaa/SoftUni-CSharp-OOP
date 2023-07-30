using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Repositories.Contracts;

namespace UniversityCompetition.Repositories;

public class SubjectRepository : IRepository<ISubject>
{
    //Fields
    private ICollection<ISubject> subjects;

    //Constructor
    public SubjectRepository()
    {
        subjects = new List<ISubject>();
    }

    //Properties
    public IReadOnlyCollection<ISubject> Models => subjects as IReadOnlyCollection<ISubject>;

    //Methods
    public void AddModel(ISubject model) => subjects.Add(model);

    public ISubject FindById(int id) => subjects.FirstOrDefault(s => s.Id == id);

    public ISubject FindByName(string name) => subjects.FirstOrDefault(s => s.Name == name);
}
