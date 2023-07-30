using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityCompetition.Models;

public class TechnicalSubject : Subject
{
    //Fields
    private const double defaultRate = 1.3;

    //Constructor
    public TechnicalSubject(int id, string name) : base(id, name, defaultRate) { }
}
