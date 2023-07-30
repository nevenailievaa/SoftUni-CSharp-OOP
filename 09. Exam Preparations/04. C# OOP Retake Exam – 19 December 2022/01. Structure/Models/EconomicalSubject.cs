using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityCompetition.Models;

public class EconomicalSubject : Subject
{
    //Fields
    private const double defaultRate = 1;

    //Constructor
    public EconomicalSubject(int id, string name) : base(id, name, defaultRate) { }
}
