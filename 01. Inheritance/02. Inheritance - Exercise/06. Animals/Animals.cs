using System;

namespace Animals;

public abstract class Animal
{
    //Fields
    private string name;

    private int age;

    private string gender;

    //Constructor
    public Animal(string name, int age, string gender)
    {
        Name = name;
        Age = age;
        Gender = gender;
    }

    //Properties
    public string Name
    {
        get
        {
            return name;
        }
        private set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Invalid input!");
            }

            name = value;
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
                throw new ArgumentException("Invalid input!");
            }

            age = value;
        }
    }

    public string Gender
    {
        get
        {
            return gender;
        }
        private set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Invalid input!");
            }

            gender = value;
        }
    }

    //Methods
    public abstract string ProduceSound();

    public override string ToString()
        => $"{Name} {Age} {Gender}{Environment.NewLine}" +
        $"{ProduceSound()}";
}