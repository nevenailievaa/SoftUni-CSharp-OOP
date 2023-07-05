using System.Collections.Concurrent;
using System.Globalization;

//Input
string[] bankAccountsInfo = Console.ReadLine().Split(",");

//Bank Accounts
Dictionary<int, double> bankAccounts = new Dictionary<int, double>();

for (int i = 0; i < bankAccountsInfo.Length; i++)
{
    string[] bankAccount = bankAccountsInfo[i].Split("-");
    int accountNumber = int.Parse(bankAccount[0]);
    double accountBalance = double.Parse(bankAccount[1]);

    bankAccounts.Add(accountNumber, accountBalance);
}

//Commands Manipulation
string command = string.Empty;

while ((command = Console.ReadLine()) != "End")
{
    string[] commandInfo = command.Split(" ");

    string commandType = commandInfo[0];
    int accountNumber = int.Parse(commandInfo[1]);
    double balance = double.Parse(commandInfo[2]);

    try
    {
        if (commandType != "Deposit" && commandType != "Withdraw")
        {
            throw new InvalidCommandException(InvalidCommandException.InvalidCommandExceptionMessage);
        }
        if (!bankAccounts.ContainsKey(accountNumber))
        {
            throw new InvalidAccountException(InvalidAccountException.InvalidAccountExceptionMessage);
        }

        //Deposit Command
        if (commandType == "Deposit")
        {
            bankAccounts[accountNumber] += balance;
        }

        //Withdraw Command
        else if (commandType == "Withdraw")
        {
            if (bankAccounts[accountNumber] - balance < 0)
            {
                throw new InsufficientBalanceException(InsufficientBalanceException.InsufficientBalanceExceptionMessage);
            }
            bankAccounts[accountNumber] -= balance;
        }

        //Output
        Console.WriteLine($"Account {accountNumber} has new balance: {bankAccounts[accountNumber]:f2}");
    }
    catch (InvalidCommandException ex)
    {
        Console.WriteLine(ex.Message);
    }
    catch (InvalidAccountException ex)
    {
        Console.WriteLine(ex.Message);
    }
    catch (InsufficientBalanceException ex)
    {
        Console.WriteLine(ex.Message);
    }
    finally
    {
        Console.WriteLine("Enter another command");
    }
}

//Exception Classes
internal class InvalidCommandException : Exception
{
    //Messages
    public const string InvalidCommandExceptionMessage = "Invalid command!";

    //Constructor
    public InvalidCommandException(string invalidCommandExceptionMessage) : base(invalidCommandExceptionMessage) { }
}

internal class InvalidAccountException : Exception
{
    //Messages
    public const string InvalidAccountExceptionMessage = "Invalid account!";

    //Constructor
    public InvalidAccountException(string invalidAccountExceptionMessage) : base(invalidAccountExceptionMessage) { }
}

internal class InsufficientBalanceException : Exception
{
    //Messages
    public const string InsufficientBalanceExceptionMessage = "Insufficient balance!";

    //Constructor
    public InsufficientBalanceException(string insufficientBalanceExceptionMessage) : base(insufficientBalanceExceptionMessage) { }
}
