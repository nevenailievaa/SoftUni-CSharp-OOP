using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLoan.Models;

public class Student : Client
{
    //Constructor
    public Student(string name, string id, double income) : base(name, id, 2, income) { }

    //Methods
    public override void IncreaseInterest()
    {
        this.Interest++;
    }
}
