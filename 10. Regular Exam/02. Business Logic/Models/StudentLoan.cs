using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLoan.Models;

public class StudentLoan : Loan
{
    //Fields
    private const int defaultInterestRate = 1;
    private const double defaultAmount = 10000;

    //Constructor
    public StudentLoan() : base(defaultInterestRate, defaultAmount) { }
}
