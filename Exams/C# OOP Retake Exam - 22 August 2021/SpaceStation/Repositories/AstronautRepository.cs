namespace SpaceStation.Repositories
{
    using SpaceStation.Models.Astronauts;
    using SpaceStation.Models.Astronauts.Contracts;
    using SpaceStation.Repositories.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class AstronautRepository : IRepository<IAstronaut>
    {

        private readonly List<IAstronaut> models;

        public AstronautRepository()
        {
            this.models = new List<IAstronaut>();
        }

        public IReadOnlyCollection<IAstronaut> Models => models;

        public void Add(IAstronaut model)
        {
            this.models.Add(model);
        }

        public IAstronaut FindByName(string name)
        {
            var astronaut = models.FirstOrDefault(x => x.Name == name);
            return astronaut;
        }

        public bool Remove(IAstronaut model)
        {
            return this.models.Remove(model);
        }
    }
}
