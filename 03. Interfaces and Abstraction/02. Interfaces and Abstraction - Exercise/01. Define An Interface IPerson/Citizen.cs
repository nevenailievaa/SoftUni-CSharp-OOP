namespace PersonInfo;

public class Citizen : IPerson
{
    //Fields
    private string name;
    private int age;

    //Constructor
    public Citizen(string name, int age)
    {
        Name = name;
        Age = age;
    }

    //Properties
    public string Name { get => name; set => name = value; }
    public int Age { get => age; set => age = value; }
}
