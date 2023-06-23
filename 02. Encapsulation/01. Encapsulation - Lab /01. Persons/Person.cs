namespace PersonsInfo;

public class Person
{
    //Constructor
    public Person(string firstName, string lastName, int age)
    {
        FirstName = firstName;
        LastName = lastName;
        Age = age;
    }

    //Properties
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public int Age { get; private set; }

    //Methods
    public override string ToString()
    {
        return $"{FirstName} {LastName} is {Age} years old.";
    }
}
