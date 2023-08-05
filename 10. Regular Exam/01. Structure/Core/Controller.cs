using BankLoan.Core.Contracts;
using BankLoan.Models;
using BankLoan.Models.Contracts;
using BankLoan.Repositories;
using BankLoan.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BankLoan.Core;

public class Controller : IController
{
    //Fields
    private LoanRepository loans;
    private BankRepository banks;

    //Constructor
    public Controller()
    {
        loans = new LoanRepository();
        banks = new BankRepository();
    }

    //Methods
    public string AddBank(string bankTypeName, string name)
    {
        IBank bank;

        //Checking The Type
        if (bankTypeName == nameof(BranchBank))
        {
            bank = new BranchBank(name);
        }
        else if (bankTypeName == nameof(CentralBank))
        {
            bank = new CentralBank(name);
        }
        else
        {
            throw new ArgumentException(ExceptionMessages.BankTypeInvalid);
        }

        //Successfully Adding The Bank
        banks.AddModel(bank);
        return String.Format(OutputMessages.BankSuccessfullyAdded, bankTypeName);
    }

    public string AddClient(string bankName, string clientTypeName, string clientName, string id, double income)
    {
        IClient currentClient;

        //Checking The Client's Type
        if (clientTypeName == nameof(Student))
        {
            currentClient = new Student(clientName, id, income);
        }
        else if (clientTypeName == nameof(Adult))
        {
            currentClient = new Adult(clientName, id, income);
        }
        else
        {
            throw new ArgumentException(ExceptionMessages.ClientTypeInvalid);
        }

        IBank currentBank = banks.FirstModel(bankName);

        //Client Type Name Is Not A Valid Client Type Of The Current Bank
        if (currentBank.GetType().Name == nameof(BranchBank) && currentClient.GetType().Name == nameof(Adult)
            || currentBank.GetType().Name == nameof(CentralBank) && currentClient.GetType().Name == nameof(Student))
        {
            return OutputMessages.UnsuitableBank;
        }

        //Successfully Adding The Client To The Bank
        currentBank.AddClient(currentClient);
        return String.Format(OutputMessages.ClientAddedSuccessfully, clientTypeName, bankName);
    }

    public string AddLoan(string loanTypeName)
    {
        ILoan loan;

        //Checking The Type
        if (loanTypeName == nameof(StudentLoan))
        {
            loan = new StudentLoan();
        }
        else if (loanTypeName == nameof(MortgageLoan))
        {
            loan = new MortgageLoan();
        }
        else
        {
            throw new ArgumentException(ExceptionMessages.LoanTypeInvalid);
        }

        //Successfully Adding The Bank
        loans.AddModel(loan);
        return String.Format(OutputMessages.LoanSuccessfullyAdded, loanTypeName);
    }

    public string FinalCalculation(string bankName)
    {
        IBank currentBank = banks.FirstModel(bankName);
        double sum = currentBank.Clients.Sum(c => c.Income) + currentBank.Loans.Sum(l => l.Amount);

        return String.Format(OutputMessages.BankFundsCalculated, bankName, $"{sum:f2}");
    }

    public string ReturnLoan(string bankName, string loanTypeName)
    {
        ILoan currentLoan = loans.FirstModel(loanTypeName);

        if (currentLoan == null)
        {
            return String.Format(ExceptionMessages.MissingLoanFromType, loanTypeName);
        }

        //Successfully Returning The Loan
        IBank currentBank = banks.FirstModel(bankName);
        currentBank.AddLoan(currentLoan);
        loans.RemoveModel(currentLoan);

        return String.Format(OutputMessages.LoanReturnedSuccessfully, loanTypeName, bankName);
    }

    public string Statistics()
    {
        StringBuilder sb = new StringBuilder();

        foreach (var bank in banks.Models)
        {
            sb.AppendLine(bank.GetStatistics());
        }

        return sb.ToString().TrimEnd();
    }
}
