namespace PersonsInfo;

public class Team
{
    //Fields
    private string name;
    private List<Person> firstTeam;
    private List<Person> reserveTeam;

    //Constructor
    public Team(string name)
    {
        this.name = name;
        firstTeam = new List<Person>();
        reserveTeam = new List<Person>();
    }

    //Properties
    public string Name { get { return name; } private set { name = value; } }
    public IReadOnlyCollection<Person> FirstTeam => firstTeam.AsReadOnly();
    public IReadOnlyCollection<Person> ReserveTeam => reserveTeam.AsReadOnly();

    //Methods
    public void AddPlayer(Person person)
    {
        if (person.Age < 40)
        {
            firstTeam.Add(person);
        }
        else
        {
            reserveTeam.Add(person);
        }
    }
}
