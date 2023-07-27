using EDriveRent.Models.Contracts;
using EDriveRent.Utilities.Messages;
using System;

namespace EDriveRent.Models;

public class User : IUser
{
    //Fields
    private string firstName;
    private string lastName;
    private double rating;
    private string drivingLicenseNumber;
    private bool isBlocked;

    //Constructor
    public User(string firstName, string lastName, string drivingLicenseNumber)
    {
        this.firstName = firstName;
        this.lastName = lastName;
        this.rating = 0;
        this.drivingLicenseNumber = drivingLicenseNumber;
        this.isBlocked = false;
    }

    //Properties
    public string FirstName
    {
        get => firstName;
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(ExceptionMessages.FirstNameNull);
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
                throw new ArgumentException(ExceptionMessages.LastNameNull);
            }
            lastName = value;
        }
    }

    public double Rating { get => rating; private set => rating = value; }

    public string DrivingLicenseNumber
    {
        get => drivingLicenseNumber;
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(ExceptionMessages.DrivingLicenseRequired);
            }
            firstName = value;
        }
    }

    public bool IsBlocked { get => isBlocked; private set => isBlocked = value; }

    //Methods
    public void DecreaseRating()
    {
        if (Rating - 2 < 0)
        {
            Rating = 0;
            IsBlocked = true;
        }
        else
        {
            Rating -= 2;
        }
    }

    public void IncreaseRating()
    {
        if (Rating + 0.5 >= 10)
        {
            Rating = 10;
        }
        else
        {
            Rating += 0.5;
        }
    }

    public override string ToString()
    {
        return $"{FirstName} {LastName} Driving license: {DrivingLicenseNumber} Rating: {Rating}";
    }
}
