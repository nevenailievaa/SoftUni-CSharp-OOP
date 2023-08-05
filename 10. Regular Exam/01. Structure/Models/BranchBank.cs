using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLoan.Models;

public class BranchBank : Bank
{
    //Fields
    private const int defaultCapacity = 25;

    //Constructor
    public BranchBank(string name) : base(name, defaultCapacity) { }
}
