namespace PersonInfo;

public class Citizen : IPerson, IIdentifiable, IBirthable
{
    //Fields
    private string name;
    private int age;
    private string id;
    private string birthDate;

    //Constructor
    public Citizen(string name, int age, string id, string birthDate)
    {
        Name = name;
        Age = age;
        Id = id;
        Birthdate = birthDate;
    }

    //Properties
    public string Name { get => name; set => name = value; }
    public int Age { get => age; set => age = value; }
    public string Id { get => id; set => id = value; }
    public string Birthdate { get => birthDate; set => birthDate = value; }
}
