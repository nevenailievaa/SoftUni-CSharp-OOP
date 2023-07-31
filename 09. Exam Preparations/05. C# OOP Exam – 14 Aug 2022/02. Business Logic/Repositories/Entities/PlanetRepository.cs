using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanetWars.Repositories.Entities
{
    public class PlanetRepository : IRepository<IPlanet>
    {
        //Fields
        private List<IPlanet> planets;

        //Constructor
        public PlanetRepository()
        {
            this.planets = new List<IPlanet>();
        }

        //Properties
        public IReadOnlyCollection<IPlanet> Models => this.planets;

        //Methods
        public void AddItem(IPlanet model)
        {
            this.planets.Add(model);
        }

        public IPlanet FindByName(string name) => this.planets.FirstOrDefault(x => x.Name == name);
        public bool RemoveItem(string planetName) => this.planets.Remove(this.planets.FirstOrDefault(x => x.Name == planetName));
    }
}
