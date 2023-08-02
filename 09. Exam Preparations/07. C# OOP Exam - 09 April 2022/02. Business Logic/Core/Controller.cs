using Formula1.Core.Contracts;
using Formula1.Models;
using Formula1.Models.Contracts;
using Formula1.Repositories;
using Formula1.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Formula1.Core;

public class Controller : IController
{
    //Fields
    private PilotRepository pilotRepository;
    private RaceRepository raceRepository;
    private FormulaOneCarRepository carRepository;

    //Constructor
    public Controller()
    {
        pilotRepository = new PilotRepository();
        raceRepository = new RaceRepository();
        carRepository = new FormulaOneCarRepository();
    }

    //Methods
    public string AddCarToPilot(string pilotName, string carModel)
    {
        //A Pilot With This Name Already Exists
        IPilot currentPilot = pilotRepository.FindByName(pilotName);

        if (currentPilot == null || currentPilot.Car != null)
        {
            throw new InvalidOperationException(String.Format(ExceptionMessages.PilotDoesNotExistOrHasCarErrorMessage, pilotName));
        }

        //The Car Model Does Not Exist
        IFormulaOneCar currentCar = carRepository.FindByName(carModel);

        if (currentCar == null)
        {
            throw new NullReferenceException(String.Format(ExceptionMessages.CarDoesNotExistErrorMessage, carModel));
        }

        //Successfully Adding Car To Pilot
        currentPilot.AddCar(currentCar);
        carRepository.Remove(currentCar);
        return String.Format(OutputMessages.SuccessfullyPilotToCar, pilotName, currentCar.GetType().Name, carModel);
    }

    public string AddPilotToRace(string raceName, string pilotFullName)
    {
        //Race With That Name Does Not Exist
        IRace currentRace = raceRepository.FindByName(raceName);

        if (currentRace == null)
        {
            throw new NullReferenceException(String.Format(ExceptionMessages.RaceDoesNotExistErrorMessage, raceName));
        }

        //Pilot With That Name Does Not Exist OR Pilot Can Not Race OR Pilot Is Already In The Race
        IPilot currentPilot = pilotRepository.FindByName(pilotFullName);

        if (currentPilot == null || !currentPilot.CanRace || currentRace.Pilots.Contains(currentPilot))
        {
            throw new InvalidOperationException(String.Format(ExceptionMessages.PilotDoesNotExistErrorMessage, pilotFullName));
        }

        //Successfully Adding The Pilot To The Race
        currentRace.AddPilot(currentPilot);
        return String.Format(OutputMessages.SuccessfullyAddPilotToRace, pilotFullName, raceName);
    }

    public string CreateCar(string type, string model, int horsepower, double engineDisplacement)
    {
        //A Car Of This Model Already Exists
        if (carRepository.Models.Any(c => c.Model == model))
        {
            throw new InvalidOperationException(String.Format(ExceptionMessages.CarExistErrorMessage, model));
        }

        //Creating Car
        IFormulaOneCar currentCar;

        if (type == nameof(Ferrari))
        {
            currentCar = new Ferrari(model, horsepower, engineDisplacement);
        }
        else if (type == nameof(Williams))
        {
            currentCar = new Williams(model, horsepower, engineDisplacement);
        }
        //Car Type Is Invalid
        else
        {
            throw new InvalidOperationException(String.Format(ExceptionMessages.InvalidTypeCar, type));
        }

        carRepository.Add(currentCar);
        return String.Format(OutputMessages.SuccessfullyCreateCar, type, model);
    }

    public string CreatePilot(string fullName)
    {
        //Pilot With That Name Already Exists
        if (pilotRepository.FindByName(fullName) != null)
        {
            throw new InvalidOperationException(String.Format(ExceptionMessages.PilotExistErrorMessage, fullName));
        }

        //Pilot Added Successfully
        pilotRepository.Add(new Pilot(fullName));
        return String.Format(OutputMessages.SuccessfullyCreatePilot, fullName);
    }

    public string CreateRace(string raceName, int numberOfLaps)
    {
        //Race With That Name Already Exists
        if (raceRepository.FindByName(raceName) != null)
        {
            throw new InvalidOperationException(String.Format(ExceptionMessages.RaceExistErrorMessage, raceName));
        }

        //Creating Race
        raceRepository.Add(new Race(raceName, numberOfLaps));
        return String.Format(OutputMessages.SuccessfullyCreateRace, raceName);
    }

    public string PilotReport()
    {
        StringBuilder sb = new StringBuilder();

        foreach (var pilot in pilotRepository.Models.OrderByDescending(p => p.NumberOfWins))
        {
            sb.AppendLine(pilot.ToString());
        }

        return sb.ToString().TrimEnd();
    }

    public string RaceReport()
    {
        StringBuilder sb = new StringBuilder();

        foreach (var race in raceRepository.Models.Where(r => r.TookPlace is true))
        {
            sb.AppendLine(race.RaceInfo());
        }

        return sb.ToString().TrimEnd();
    }

    public string StartRace(string raceName)
    {
        //Race With That Name Does Not Exist
        IRace currentRace = raceRepository.FindByName(raceName);

        if (currentRace == null)
        {
            throw new NullReferenceException(String.Format(ExceptionMessages.RaceDoesNotExistErrorMessage, raceName));
        }

        //Race Has Less Than 3 Pilots
        if (currentRace.Pilots.Count < 3)
        {
            throw new InvalidOperationException(String.Format(ExceptionMessages.InvalidRaceParticipants, raceName));
        }

        //Race Has Been Already Executed
        if (currentRace.TookPlace)
        {
            throw new InvalidOperationException(String.Format(ExceptionMessages.RaceTookPlaceErrorMessage, raceName));
        }

        //Successfull -  Pilots Start Racing
        StringBuilder sb = new StringBuilder();
        int counter = 0;

        List<IPilot> sortedPilots = currentRace.Pilots.OrderByDescending(p => p.Car.RaceScoreCalculator(currentRace.NumberOfLaps)).ToList();

        for (int i = 0; i < sortedPilots.Count; i++)
        {
            if (i == 0)
            {
                sb.AppendLine($"Pilot {sortedPilots[i].FullName} wins the {raceName} race.");
                sortedPilots[i].WinRace();
            }
            else if (i == 1)
            {
                sb.AppendLine($"Pilot {sortedPilots[i].FullName} is second in the {raceName} race.");

            }
            else if (i == 2)
            {
                sb.AppendLine($"Pilot {sortedPilots[i].FullName} is third in the {raceName} race.");
                break;
            }
        }

        currentRace.TookPlace = true;
        return sb.ToString().TrimEnd();
    }
}