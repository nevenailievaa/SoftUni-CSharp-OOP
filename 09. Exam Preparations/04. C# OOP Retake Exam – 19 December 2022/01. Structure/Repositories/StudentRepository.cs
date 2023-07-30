using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityCompetition.Models;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Repositories.Contracts;

namespace UniversityCompetition.Repositories
{
    public class StudentRepository : IRepository<IStudent>
    {
        //Fields
        private ICollection<IStudent> students;

        //Constructor
        public StudentRepository()
        {
            students = new List<IStudent>();
        }

        //Properties
        public IReadOnlyCollection<IStudent> Models => students as IReadOnlyCollection<IStudent>;

        //Methods
        public void AddModel(IStudent model) => students.Add(model);

        public IStudent FindById(int id) => students.FirstOrDefault(s => s.Id == id);

        public IStudent FindByName(string name)
        {
            string[] fullName = name.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string firstName = fullName[0];
            string lastName = fullName[1];

            return students.FirstOrDefault(s => s.FirstName == firstName && s.LastName == lastName);
        }
        
    }
}
