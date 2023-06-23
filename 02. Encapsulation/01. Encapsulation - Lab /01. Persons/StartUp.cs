namespace PersonsInfo
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            //INPUT
            int peopleCount = int.Parse(Console.ReadLine());

            //ACTION
            List<Person> people = new List<Person>();

            for (int i = 0; i < peopleCount; i++)
            {
                string[] personInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                Person person = new Person(personInfo[0], personInfo[1], int.Parse(personInfo[2]));
                people.Add(person);
            }

            //OUTPUT
            foreach (Person person in people.OrderBy(p => p.FirstName))
            {
                Console.WriteLine(person);
            }
        }
    }
}