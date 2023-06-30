using BirthdayCelebrations.Models;
using BirthdayCelebrations.Models.Interfaces;

public class StartUp
{
    static void Main()
    {
        //Input
        string command = string.Empty;
        List<IBirthable> entersList = new List<IBirthable>();

        while ((command = Console.ReadLine()) != "End")
        {
            string[] enterInfo = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            //Citizen
            if (enterInfo[0] == "Citizen")
            {
                IBirthable citizen = new Citizen(enterInfo[1], int.Parse(enterInfo[2]), enterInfo[3], enterInfo[4]);
                entersList.Add(citizen);
            }
            else if (enterInfo[0] == "Pet")
            {
                IBirthable pet = new Pet(enterInfo[1], enterInfo[2]);
                entersList.Add(pet);
            }
        }

        string year = Console.ReadLine();
        List<IBirthable> detainedEnters = new List<IBirthable>();

        for (int i = 0; i < entersList.Count; i++)
        {
            if (entersList[i].Birthdate.EndsWith(year))
            {
                detainedEnters.Add(entersList[i]);
            }
        }

        //Output
        Console.WriteLine(String.Join(Environment.NewLine, detainedEnters.Select(d => d.Birthdate)));
    }
}