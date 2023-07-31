using System;
using System.Collections.Generic;
using System.Text;

namespace PlanetWars.Models.MilitaryUnits.Entities
{
    public class AnonymousImpactUnit : IMilitaryUnit
    {
        private const double cost = 30;
        public AnonymousImpactUnit() : base(cost)
        {
        }
    }
}
