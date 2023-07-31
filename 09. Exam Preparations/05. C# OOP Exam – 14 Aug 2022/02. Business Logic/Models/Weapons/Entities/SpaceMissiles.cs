using PlanetWars.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlanetWars.Models.Weapons.Entities
{
    public class SpaceMissiles : Weapon
    {
        private const double price = 8.75;
        public SpaceMissiles(int destructionLevel) : base(price, destructionLevel)
        {

        }

    }
}
