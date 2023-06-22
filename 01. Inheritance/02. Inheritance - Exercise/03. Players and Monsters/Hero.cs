namespace PlayersAndMonsters;

public class Hero
{
    //Constructor
    public Hero(string username, int level)
    {
        Username = username;
        Level = level;
    }

    //Properties
    public string Username { get; set; }
    public int Level { get; set; }

    //Methods
    public override string ToString()
    {
        return $"Type: {GetType().Name} Username: {Username} Level: {Level}";
    }
}
