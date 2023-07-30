using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Xml.Linq;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Utilities.Messages;

namespace UniversityCompetition.Models;

public class University : IUniversity
{
    //Fields
    private int id;
    private string name;
    private string category;
    private int capacity;
    private ICollection<int> requiredSubjects;

    //Constructor
    public University(int id, string name, string category, int capacity, ICollection<int> requiredSubjects)
    {
        Id = id;
        Name = name;
        Category = category;
        Capacity = capacity;
        this.requiredSubjects = requiredSubjects;
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

    public string Category
    {
        get => category;
        private set
        {
            if (value != "Technical" && value != "Economical" && value != "Humanity")
            {
                throw new ArgumentNullException(ExceptionMessages.CategoryNotAllowed, value);
            }
            category = value;
        }
    }

    public int Capacity
    {
        get => capacity;
        private set
        {
            if (value < 0)
            {
                throw new ArgumentNullException(ExceptionMessages.CapacityNegative);
            }
            capacity = value;
        }
    }

    public IReadOnlyCollection<int> RequiredSubjects => requiredSubjects as IReadOnlyCollection<int>;
}
