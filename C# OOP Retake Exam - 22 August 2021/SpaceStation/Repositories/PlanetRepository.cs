namespace SpaceStation.Repositories
{
    using SpaceStation.Models.Planets;
    using SpaceStation.Models.Planets.Contracts;
    using SpaceStation.Repositories.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class PlanetRepository : IRepository<IPlanet>
    {
        private readonly List<IPlanet> models;

        public PlanetRepository()
        {
            this.models=new List<IPlanet>();
        }

        public IReadOnlyCollection<IPlanet> Models => models;

        public void Add(IPlanet model)
        {
            this.models.Add(model);
        }

        public IPlanet FindByName(string name)
        {
            var planet = models.FirstOrDefault(x => x.Name == name);
            return planet;
        }

        public bool Remove(IPlanet model)
        {
            return this.models.Remove(model);
        }
    }
}
