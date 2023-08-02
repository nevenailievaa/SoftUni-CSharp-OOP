using Formula1.Models.Contracts;
using Formula1.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formula1.Models;

public class Race : IRace
{
    //Fields
    private string raceName;
    private int numberOfLaps;
    private List<IPilot> pilots;

    //Constructor
    public Race(string raceName, int numberOfLaps)
    {
        RaceName = raceName;
        NumberOfLaps = numberOfLaps;
    }


    //Properties
    public string RaceName
    {
        get => raceName;
        private set
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length < 5)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.InvalidRaceName, value));
            }
            raceName = value;
        }
    }

    public int NumberOfLaps
    {
        get => numberOfLaps;
        private set
        {
            if (value < 1)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.InvalidLapNumbers, value));
            }
            numberOfLaps = value;
        }
    }

    public bool TookPlace { get; set; } = false;

    public ICollection<IPilot> Pilots => pilots;

    //Methods
    public void AddPilot(IPilot pilot) => pilots.Add(pilot);

    public string RaceInfo()
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine($"The {RaceName} race has:");
        sb.AppendLine($"Participants: {pilots.Count}");
        sb.AppendLine($"Number of laps: {NumberOfLaps}");
        sb.Append("Took place: ");

        if (TookPlace)
        {
            sb.Append("Yes");
        }
        else
        {
            sb.Append("No");
        }

        return sb.ToString();
    }
}