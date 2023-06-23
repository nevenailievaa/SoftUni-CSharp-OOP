namespace PersonsInfo
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            //INPUT
            int peopleCount = int.Parse(Console.ReadLine());

            List<Person> people = new List<Person>();
            Team team = new Team("SoftUni");

            for (int i = 0; i < peopleCount; i++)
            {
                string[] commandInfo = Console.ReadLine().Split();
                Person person = new Person(commandInfo[0], commandInfo[1], int.Parse(commandInfo[2]), decimal.Parse(commandInfo[3]));

                people.Add(person);
                team.AddPlayer(person);
            }

            //OUTPUT
            Console.WriteLine($"First team has {team.FirstTeam.Count} players.");
            Console.WriteLine($"Reserve team has {team.ReserveTeam.Count} players.");
        }
    }
}