using System.Text;

namespace Person;

public class Person
{
    //Constructor
    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }

    //Properties
    public string Name { get; set; }
    public int Age { get; set; }

    //Methods
    public override string ToString()
    {
        StringBuilder stringBuilder = new StringBuilder();

        stringBuilder.Append($"Name: {Name}, Age: {Age}");

        return stringBuilder.ToString();
    }
}
