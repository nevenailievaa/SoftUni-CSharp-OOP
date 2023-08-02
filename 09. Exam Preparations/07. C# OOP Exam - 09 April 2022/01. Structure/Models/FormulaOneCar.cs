using Formula1.Models.Contracts;
using Formula1.Utilities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formula1.Models;

public abstract class FormulaOneCar : IFormulaOneCar
{
    //Fields
    private string model;
    private int horsePower;
    private double engineDisplacement;

    //Constructor
    protected FormulaOneCar(string model, int horsepower, double engineDisplacement)
    {
        Model = model;
        Horsepower = horsepower;
        EngineDisplacement = engineDisplacement;
    }

    //Properties
    public string Model
    {
        get => model;
        private set
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length < 3)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.InvalidF1CarModel, value));
            }
            model = value;
        }
    }

    public int Horsepower
    {
        get => horsePower;
        private set
        {
            if (value < 900 || value > 1050)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.InvalidF1HorsePower, value));
            }
            horsePower = value;
        }
    }

    public double EngineDisplacement
    {
        get => engineDisplacement;
        private set
        {
            if (value < 1.6 || value > 2)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.InvalidF1EngineDisplacement, value));
            }
            engineDisplacement = value;
        }
    }

    //Methods
    public double RaceScoreCalculator(int laps) => EngineDisplacement / Horsepower * laps;
}