using BankLoan.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLoan.Models;

public abstract class Loan : ILoan
{
    //Constructor
    protected Loan(int interestRate, double amount)
    {
        InterestRate = interestRate;
        Amount = amount;
    }

    //Properties
    public int InterestRate { get; private set; }

    public double Amount { get; private set; }
}
