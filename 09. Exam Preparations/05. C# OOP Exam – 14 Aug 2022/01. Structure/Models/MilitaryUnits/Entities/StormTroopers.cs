using System;
using System.Collections.Generic;
using System.Text;

namespace PlanetWars.Models.MilitaryUnits.Entities
{
    public class StormTroopers : MilitaryUnit
    {
        private const double cost = 2.5;
        public StormTroopers() : base(cost)
        {
        }
    }
}
