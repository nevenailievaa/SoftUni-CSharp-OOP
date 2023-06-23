namespace PersonsInfo;

public class Person
{
    //Constructor
    public Person(string firstName, string lastName, int age, decimal salary)
    {
        FirstName = firstName;
        LastName = lastName;
        Age = age;
        Salary = salary;
    }

    //Properties
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public int Age { get; private set; }
    public decimal Salary { get; private set; }

    //Methods
    public override string ToString()
    {
        return $"{FirstName} {LastName} receives {Salary:f2} leva.";
    }

    public decimal IncreaseSalary(decimal percentage)
    {
        if (Age < 30)
        {
            percentage /= 2;
        }

        Salary += (Salary * (percentage / 100));
        return Salary;
    }
}