using PlanetWars.Core.Contracts;
using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.MilitaryUnits.Entities;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Models.Planets.Entities;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Models.Weapons.Entities;
using PlanetWars.Repositories.Entities;
using PlanetWars.Utilities.Messages;
using System;
using System.Linq;
using System.Text;
using IMilitaryUnit = PlanetWars.Models.MilitaryUnits.Contracts.IMilitaryUnit;

namespace PlanetWars.Core
{
    public class Controller : IController
    {
        private PlanetRepository planets;

        public Controller()
        {
            this.planets = new PlanetRepository();
        }
        public string CreatePlanet(string name, double budget)
        {
            IPlanet planet = new Planet(name, budget);

            if (this.planets.FindByName(name) != default)
            {
                return string.Format(OutputMessages.ExistingPlanet, name);
            }
            else
            {
                this.planets.AddItem(planet);
                return string.Format(OutputMessages.NewPlanet, name);
            }
        }

        public string AddUnit(string unitName, string planetName)
        {
            IPlanet planet = this.planets.FindByName(planetName);

            if (planet == default)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }

            if (unitName != nameof(AnonymousImpactUnit) &&
                unitName != nameof(SpaceForces) &&
                unitName != nameof(StormTroopers))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ItemNotAvailable, unitName));
            }

            if (planet.Army.Any(u => u.GetType().Name == unitName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnitAlreadyAdded, unitName, planetName));
            }

            IMilitaryUnit unit;

            if (unitName == nameof(SpaceForces))
            {
                unit = new SpaceForces();
            }
            else if (unitName == nameof(StormTroopers))
            {
                unit = new StormTroopers();
            }
            else
            {
                unit = new AnonymousImpactUnit();
            }

            planet.Spend(unit.Cost);
            planet.AddUnit(unit);

            return string.Format(OutputMessages.UnitAdded, unitName, planetName);
        }

        public string AddWeapon(string planetName, string weaponName, int destructionLevel)
        {
            IPlanet planet = planets.FindByName(planetName);

            if (planet == default)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }

            if (weaponName != nameof(BioChemicalWeapon) &&
                weaponName != nameof(NuclearWeapon) &&
                weaponName != nameof(SpaceMissiles))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ItemNotAvailable, weaponName));
            }

            if (planet.Weapons.Any(w => w.GetType().Name == weaponName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.WeaponAlreadyAdded, weaponName, planetName));
            }

            IWeapon weapon;

            if (weaponName == nameof(NuclearWeapon))
            {
                weapon = new NuclearWeapon(destructionLevel);
            }
            else if (weaponName == nameof(SpaceMissiles))
            {
                weapon = new SpaceMissiles(destructionLevel);
            }
            else
            {
                weapon = new BioChemicalWeapon(destructionLevel);
            }

            planet.Spend(weapon.Price);
            planet.AddWeapon(weapon);

            return string.Format(OutputMessages.WeaponAdded, planetName, weaponName);
        }

        public string SpecializeForces(string planetName)
        {
            IPlanet planet = planets.FindByName(planetName);

            if (planet == default)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }
            else if (planet.Army.Count == 0)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.NoUnitsFound));
            }
            else
            {
                double specializeCost = 1.25;
                planet.TrainArmy();
                planet.Spend(specializeCost);

                return string.Format(OutputMessages.ForcesUpgraded, planetName);
            }
        }

        public string SpaceCombat(string planetOne, string planetTwo)
        {
            IPlanet firstPlanet = planets.FindByName(planetOne);
            IPlanet secondPlanet = planets.FindByName(planetTwo);

            double firstPlanetHalfBudget = firstPlanet.Budget / 2;
            double secondPlanetHalfBudget = secondPlanet.Budget / 2;

            double firstCalculatedValue = firstPlanet.Army.Sum(x => x.Cost) +
                                            firstPlanet.Weapons.Sum(y => y.Price);

            double secondCalculatedValue = secondPlanet.Army.Sum(x => x.Cost) +
                                            secondPlanet.Weapons.Sum(y => y.Price);

            double firstPowerRatio = firstPlanet.MilitaryPower;
            double secondPowerRatio = secondPlanet.MilitaryPower;

            bool firstHasNuclear = firstPlanet.Weapons
                .Any(w => w.GetType().Name == nameof(NuclearWeapon));

            bool secondHasNuclear = secondPlanet.Weapons
                .Any(w => w.GetType().Name == nameof(NuclearWeapon));

            var firstNuclear = firstPlanet.Weapons
                .FirstOrDefault(w => w.GetType().Name == nameof(NuclearWeapon));
            var secondNuclear = secondPlanet.Weapons
                .FirstOrDefault(w => w.GetType().Name == nameof(NuclearWeapon));

            if (firstPowerRatio > secondPowerRatio)
            {
                firstPlanet.Spend(firstPlanetHalfBudget);
                firstPlanet.Profit(secondPlanetHalfBudget);
                firstPlanet.Profit(secondCalculatedValue);

                planets.RemoveItem(secondPlanet.Name);
                return string.Format(OutputMessages.WinnigTheWar, planetOne, planetTwo);
            }
            else if (firstPowerRatio < secondPowerRatio)
            {
                secondPlanet.Spend(secondPlanetHalfBudget);
                secondPlanet.Profit(firstPlanetHalfBudget);
                secondPlanet.Profit(firstCalculatedValue);

                planets.RemoveItem(firstPlanet.Name);
                return string.Format(OutputMessages.WinnigTheWar, planetTwo, planetOne);
            }
            else
            {
                if (firstNuclear != null && secondNuclear != null)
                {
                    firstPlanet.Spend(firstPlanetHalfBudget);
                    secondPlanet.Spend(secondPlanetHalfBudget);
                    return string.Format(OutputMessages.NoWinner);
                }
                else if (firstNuclear != null)
                {
                    firstPlanet.Spend(firstPlanetHalfBudget);
                    firstPlanet.Profit(secondPlanetHalfBudget);
                    firstPlanet.Profit(secondCalculatedValue);

                    planets.RemoveItem(secondPlanet.Name);
                    return string.Format(OutputMessages.WinnigTheWar, planetOne, planetTwo);
                }
                else if (secondNuclear != null)
                {
                    secondPlanet.Spend(secondPlanetHalfBudget);
                    secondPlanet.Profit(firstPlanetHalfBudget);
                    secondPlanet.Profit(firstCalculatedValue);

                    planets.RemoveItem(firstPlanet.Name);
                    return string.Format(OutputMessages.WinnigTheWar, planetTwo, planetOne);
                }
                else
                {
                    firstPlanet.Spend(firstPlanetHalfBudget);
                    secondPlanet.Spend(secondPlanetHalfBudget);
                    return string.Format(OutputMessages.NoWinner);
                }
            }
        }

        public string ForcesReport()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("***UNIVERSE PLANET MILITARY REPORT***");

            foreach (var planet in this.planets.Models.OrderByDescending(x => x.MilitaryPower).ThenBy(x => x.Name))
            {
                sb.AppendLine(planet.PlanetInfo());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
