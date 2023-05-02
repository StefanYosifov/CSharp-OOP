namespace Formula1.Repositories
{
    using Formula1.Models.Contracts;
    using Formula1.Repositories.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class RaceRepository : IRepository<IRace>
    {
        private ICollection<IRace> models;

        public RaceRepository()
        {
            this.models= new List<IRace>();
        }

        public IReadOnlyCollection<IRace> Models =>(IReadOnlyCollection<IRace>)models;

        public void Add(IRace model)
        {
            models.Add(model);
        }

        public IRace FindByName(string name)
        {
            var race = models.FirstOrDefault(x => x.RaceName == name);
            return race;
        }

        public bool Remove(IRace model)
        {
           return this.models.Remove(model);
        }
    }
}
