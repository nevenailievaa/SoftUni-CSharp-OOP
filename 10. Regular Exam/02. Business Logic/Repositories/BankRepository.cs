using BankLoan.Models.Contracts;
using BankLoan.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BankLoan.Repositories;

public class BankRepository : IRepository<IBank>
{
    //Fields
    private List<IBank> banks;

    public BankRepository()
    {
        banks = new List<IBank>();
    }

    //Properties
    public IReadOnlyCollection<IBank> Models => banks.AsReadOnly();

    //Methods
    public void AddModel(IBank model) => banks.Add(model);

    public IBank FirstModel(string name) => banks.FirstOrDefault(b => b.Name == name);

    public bool RemoveModel(IBank model) => banks.Remove(model);
}
