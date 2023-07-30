using System;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Utilities.Messages;

namespace UniversityCompetition.Models;

public abstract class Subject : ISubject
{
    //Fields
    private string name;
    private double rate;

    //Constructor
    public Subject(int id, string name, double rate)
    {
        Id = id;
        Name = name;
        Rate = rate;
    }

    //Properties
    public int Id { get; private set; }

    public string Name
    {
        get => name;
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentNullException(ExceptionMessages.NameNullOrWhitespace);
            }
            name = value;
        }
    }

    public double Rate { get => rate; private set => rate = value; }
}