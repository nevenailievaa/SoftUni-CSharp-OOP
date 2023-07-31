using System;
using System.Collections.Generic;
using System.Xml.Linq;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Utilities.Messages;

namespace UniversityCompetition.Models;

public class Student : IStudent
{
    //Fields
    private int id;
    private string firstName;
    private string lastName;
    private readonly List<int> coveredExams;
    private IUniversity university;

    //Constructor
    public Student(int id, string firstName, string lastName)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        coveredExams = new List<int>();
    }

    //Properties
    public int Id { get => id; private set => id = value; }

    public string FirstName
    {
        get => firstName;
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(ExceptionMessages.NameNullOrWhitespace);
            }
            firstName = value;
        }
    }

    public string LastName
    {
        get => lastName;
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(ExceptionMessages.NameNullOrWhitespace);
            }
            lastName = value;
        }
    }

    public IReadOnlyCollection<int> CoveredExams => coveredExams;

    public IUniversity University => university;

    //Methods
    public void CoverExam(ISubject subject)
    {
        coveredExams.Add(subject.Id);
    }

    public void JoinUniversity(IUniversity university)
    {
        this.university = university;
    }
}
