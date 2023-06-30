namespace Telephony;

public class Smartphone : IPhone
{
    public void Call(string number)
    {
        if (number.Any(char.IsLetter))
        {
            throw new ArgumentException("Invalid number!");
        }
        Console.WriteLine($"Calling... {number}");
    }

    public void Browse(string website)
    {
        if (website.Any(char.IsDigit))
        {
            throw new ArgumentException("Invalid URL!");
        }
        Console.WriteLine($"Browsing: {website}!");
    }
}
