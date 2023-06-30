using FoodShortage.Models;
using FoodShortage.Models.Interfaces;

public class StartUp
{
    static void Main()
    {
        //Input
        int peopleCount = int.Parse(Console.ReadLine());
        List<IBuyer> buyersList = new List<IBuyer>();

        //Action
        for (int i = 0; i < peopleCount; i++)
        {
            string[] enterInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            if (enterInfo.Length == 4)
            {
                IBuyer citizen = new Citizen(enterInfo[0], int.Parse(enterInfo[1]), enterInfo[2], enterInfo[3]);
                buyersList.Add(citizen);
            }
            else if (enterInfo.Length == 3)
            {
                IBuyer rebel = new Rebel(enterInfo[0], int.Parse(enterInfo[1]), enterInfo[2]);
                buyersList.Add(rebel);
            }
        }

        //Names
        string command = string.Empty;
        List<string> namesList = new List<string>();

        while ((command = Console.ReadLine()) != "End")
        {
            namesList.Add(command);
        }

        //Filter
        foreach (var name in namesList)
        {
            if (buyersList.FirstOrDefault(b => b.Name == name) != default)
            {
                IBuyer currentBuyer = buyersList.FirstOrDefault(b => b.Name == name);
                currentBuyer.BuyFood();
            }
        }

        //Output
        Console.WriteLine(buyersList.Sum(b => b.Food));
    }
}