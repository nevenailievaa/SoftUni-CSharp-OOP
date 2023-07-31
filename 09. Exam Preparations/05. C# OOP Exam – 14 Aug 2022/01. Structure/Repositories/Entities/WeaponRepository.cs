using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanetWars.Repositories.Entities
{
    internal class WeaponRepository : IRepository<IWeapon>
    {
        //Fields
        private List<IWeapon> weapons;

        //Constructor
        public WeaponRepository()
        {
                this.weapons = new List<IWeapon>();
        }

        //Properties
        public IReadOnlyCollection<IWeapon> Models => this.weapons;

        //Methods
        public void AddItem(IWeapon model)
        {
            this.weapons.Add(model);
        }

        public IWeapon FindByName(string name) => this.weapons.FirstOrDefault(x => x.GetType().Name == name);

        public bool RemoveItem(string weaponName) => this.weapons.Remove(this.weapons.FirstOrDefault(x => x.GetType().Name == weaponName));
    }
}
