namespace BorderControl;

public class Citizen : IEnter
{ 
    //Constructor
    public Citizen(string name, int age, string id)
    {
        Name = name;
        Age = age;
        Id = id;
    }

    //Properties
    public string Name {get; private set;}
    public int Age { get; private set; }
    public string Id { get; private set; }
}
