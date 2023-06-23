using System;

namespace PersonsInfo
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            //INPUT
            int peopleCount = int.Parse(Console.ReadLine());
            List<Person> people = new List<Person>();

            for (int i = 0; i < peopleCount; i++)
            {
                var cmdArgs = Console.ReadLine().Split();
                var person = new Person(cmdArgs[0], cmdArgs[1], int.Parse(cmdArgs[2]), decimal.Parse(cmdArgs[3]));

                people.Add(person);
            }

            decimal parcentage = decimal.Parse(Console.ReadLine());
            people.ForEach(p => p.IncreaseSalary(parcentage));

            //OUTPUT
            people.ForEach(p => Console.WriteLine(p.ToString()));
        }
    }
}