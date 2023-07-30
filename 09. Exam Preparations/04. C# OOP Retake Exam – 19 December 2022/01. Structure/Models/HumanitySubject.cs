using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityCompetition.Models;

public class HumanitySubject : Subject
{
    //Fields
    private const double defaultRate = 1.15;

    //Constructor
    public HumanitySubject(int id, string name) : base(id, name, defaultRate) { }
}
