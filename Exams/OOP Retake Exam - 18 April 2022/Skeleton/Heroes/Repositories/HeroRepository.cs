namespace Heroes.Repositories
{
    using Heroes.Models.Contracts;
    using Heroes.Models.Heroes;
    using Heroes.Repositories.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class HeroRepository : IRepository<IHero>
    {
        private readonly ICollection<IHero> models;
        public IReadOnlyCollection<IHero> Models
        {
            get { return (IReadOnlyCollection<IHero>)models; }
        }


        public void Add(IHero model)
        {
            models.Add(model);
        }

        public IHero FindByName(string name)
        {
            return models.FirstOrDefault(x => x.Name == name);
        }

        public bool Remove(IHero model)
        {
            return models.Remove(model);
        }
    }


}
