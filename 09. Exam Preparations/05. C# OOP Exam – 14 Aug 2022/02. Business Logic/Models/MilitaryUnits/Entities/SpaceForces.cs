using System;
using System.Collections.Generic;
using System.Text;

namespace PlanetWars.Models.MilitaryUnits.Entities
{
    public class SpaceForces : IMilitaryUnit
    {
        private const double cost = 11;
        public SpaceForces() : base(cost)
        {
        }
    }
}
