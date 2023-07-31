using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlanetWars.Models.Weapons.Entities
{
    public abstract class Weapon : IWeapon
    {
        //Fields
        private double price;
        private int destructionLevel;

        //Constructor
        protected Weapon(double price, int destructionLevel)
        {
            Price = price;
            DestructionLevel = destructionLevel;
        }

        //Properties
        public double Price
        {
            get => price;
            private set => price = value;
        }

        public int DestructionLevel 
        { 
            get => this.destructionLevel;
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.WeaponDestructionLevelLow, nameof(NuclearWeapon), 1));
                }
                if (value > 10)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.WeaponDestructionLevelHigh, nameof(NuclearWeapon), 10));
                }
                this.destructionLevel = value;
            } 
        }
    }
}
