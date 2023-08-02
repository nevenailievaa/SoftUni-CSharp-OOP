using Formula1.Models.Contracts;
using Formula1.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formula1.Models;

public class Pilot : IPilot
{
    //Fields
    private string fullName;
    private IFormulaOneCar car;

    //Constructor
    public Pilot(string fullName)
    {
        FullName = fullName;
    }

    //Properties
    public string FullName
    {
        get => fullName;
        private set
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length < 5)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.InvalidPilot, value));
            }
            fullName = value;
        }
    }

    public IFormulaOneCar Car
    {
        get => car;
        private set
        {
            if (value == null)
            {
                throw new NullReferenceException(ExceptionMessages.InvalidCarForPilot);
            }
            car = value;
        }
    }

    public int NumberOfWins { get; private set; }

    public bool CanRace { get; private set; } = false;

    //Methods
    public void AddCar(IFormulaOneCar car)
    {
        Car = car;
        CanRace = true;
    }

    public void WinRace() => NumberOfWins++;

    public override string ToString()
    {
        return $"Pilot {FullName} has {NumberOfWins} wins.";
    }
}