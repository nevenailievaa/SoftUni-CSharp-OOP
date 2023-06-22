namespace Animals;

public class StartUp
{
    public static void Main(string[] args)
    {
        //INPUT
        string command = string.Empty;

        //ACTION
        while ((command = Console.ReadLine()) != "Beast!")
        {
            string animalType = command;
            string[] animalInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string name = animalInfo[0];
            int age = int.Parse(animalInfo[1]);
            string gender = animalInfo[2];

            if (!name.Any() || age == null || !gender.Any() || age < 0 || gender != "Male" || gender != "Female")
            {
                throw new Exception("Invalid input!");
            }

            try
            {
                if (animalType == "Dog")
                {
                    Dog dog = new Dog(name, age, gender);
                    Console.WriteLine($"{name} {age} {gender}");
                    dog.ProduceSound();
                }
                else if (animalType == "Cat")
                {
                    Cat cat = new Cat(name, age, gender);
                    Console.WriteLine($"{name} {age} {gender}");
                    cat.ProduceSound();
                }
                else if (animalType == "Frog")
                {
                    Frog frog = new Frog(name, age, gender);
                    Console.WriteLine($"{name} {age} {gender}");
                    frog.ProduceSound();
                }
                else if (animalType == "Kitten")
                {
                    Kitten kitten = new Kitten(name, age);
                    Console.WriteLine($"{name} {age} {kitten.Gender}");
                    kitten.ProduceSound();
                }
                else if (animalType == "Tomcat")
                {
                    Tomcat tomcat = new Tomcat(name, age);
                    Console.WriteLine($"{name} {age} {tomcat.Gender}");
                    tomcat.ProduceSound();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}