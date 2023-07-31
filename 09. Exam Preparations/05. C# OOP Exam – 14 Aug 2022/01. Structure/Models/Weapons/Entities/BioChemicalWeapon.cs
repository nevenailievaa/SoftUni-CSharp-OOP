using PlanetWars.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlanetWars.Models.Weapons.Entities
{
    public class BioChemicalWeapon : Weapon
    {
        private const double price = 3.2;
        public BioChemicalWeapon(int destructionLevel) : base(price, destructionLevel)
        {

        }
    }
}
