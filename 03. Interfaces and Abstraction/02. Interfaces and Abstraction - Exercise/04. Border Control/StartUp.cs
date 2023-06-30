using BorderControl;
using System.Diagnostics.Metrics;

public class StartUp
{
    static void Main()
    {
        //Input
        string command = string.Empty;
        List<IEnter> entersList = new List<IEnter>();

        while ((command = Console.ReadLine()) != "End")
        {
            string[] enterInfo = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            //Citizen
            if (enterInfo.Length == 3)
            {
                string name = enterInfo[0];
                int age = int.Parse(enterInfo[1]);
                string id = enterInfo[2];

                IEnter citizen = new Citizen(name, age, id);
                entersList.Add(citizen);
            }
            //Robot
            else if (enterInfo.Length == 2)
            {
                string model = enterInfo[0];
                string id = enterInfo[1];

                IEnter robot = new Robot(model, id);
                entersList.Add(robot);
            }
        }

        string lastDigits = Console.ReadLine();
        List<IEnter> detainedEnters = new List<IEnter>();

        for (int i = 0; i < entersList.Count; i++)
        {
            if (entersList[i].Id.EndsWith(lastDigits))
            {
                detainedEnters.Add(entersList[i]);
            }
        }

        //Output
        Console.WriteLine(String.Join(Environment.NewLine, detainedEnters.Select(d => d.Id)));
    }
}