using PlanetWars.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlanetWars.Models.Weapons.Entities
{
    public class NuclearWeapon : Weapon
    {
        private const double price = 15;
        public NuclearWeapon(int destructionLevel) : base(price, destructionLevel)
        {

        }


    }
}
