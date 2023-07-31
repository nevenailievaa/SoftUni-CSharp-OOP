using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlanetWars.Models.MilitaryUnits.Entities
{
    public abstract class MilitaryUnit : IMilitaryUnit
    {
        //Fields
        private double cost;
        private int enduranceLevel;

        //Constructor
        protected MilitaryUnit(double cost)
        {
            Cost = cost;
            this.enduranceLevel = 1;
        }

        public double Cost
        {
            get => cost;
            private set
            {
                cost = value;
            }
        }

        public int EnduranceLevel => this.enduranceLevel;

        //Methods
        public void IncreaseEndurance()
        {
            if(this.enduranceLevel == 20)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.EnduranceLevelExceeded));
            }
            this.enduranceLevel++;
        }
    }
}
