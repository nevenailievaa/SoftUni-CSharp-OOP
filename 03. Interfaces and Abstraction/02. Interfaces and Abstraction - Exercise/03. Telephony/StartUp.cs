using Telephony;

namespace PersonInfo;

public class StartUp
{
    static void Main()
    {
        //INPUT
        string[] phoneNumbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
        string[] websites = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

        //Calling
        foreach (var number in phoneNumbers)
        {
            try
            {
                if (number.Length == 10)
                {
                    IPhone smartphone = new Smartphone();
                    smartphone.Call(number);
                }
                else if (number.Length == 7)
                {
                    IPhone stationaryPhone = new StationaryPhone();
                    stationaryPhone.Call(number);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        //Browsing
        foreach (var website in websites)
        {
            try
            {
                Smartphone smartphone = new Smartphone();
                smartphone.Browse(website);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}