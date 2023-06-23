namespace PersonsInfo;

public class Person
{
    //Fields
    private string firstName;
    private string lastName;
    private int age;
    private int salary;

    //Constructor
    public Person(string firstName, string lastName, int age, decimal salary)
    {
        FirstName = firstName;
        LastName = lastName;
        Age = age;
        Salary = salary;
    }

    //Properties
    public string FirstName
    {
        get
        {
            return firstName;
        }
        private set
        {
            if (value.Length < 3)
            {
                throw new ArgumentException("First name cannot contain fewer than 3 symbols!");
            }
            else
            {
                firstName = value;
            }
        }
    }

    public string LastName
    {
        get
        {
            return lastName;
        }
        private set
        {
            if (value.Length < 3)
            {
                throw new ArgumentException("Last name cannot contain fewer than 3 symbols!");
            }
            else
            {
                lastName = value;
            }
        }
    }

    public int Age
    {
        get
        {
            return age;
        }
        private set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Age cannot be zero or a negative integer!");
            }
            else
            {
                age = value;
            }
        }
    }

    public decimal Salary
    {
        get
        {
            return salary;
        }
        private set
        {
            if (value < 650)
            {
                throw new ArgumentException("Salary cannot be less than 650 leva!");
            }
        }
    }


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