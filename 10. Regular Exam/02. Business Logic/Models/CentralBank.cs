using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLoan.Models;

public class CentralBank : Bank
{
    //Fields
    private const int defaultCapacity = 50;

    //Constructor
    public CentralBank(string name) : base(name, defaultCapacity) { }
}
