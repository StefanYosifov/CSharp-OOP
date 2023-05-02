namespace NavalVessels.Repositories
{
    using NavalVessels.Models.Contracts;
    using NavalVessels.Repositories.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class VesselRepository : IRepository<IVessel>
    {
        public VesselRepository()
        {
            models = new HashSet<IVessel>();
        }

        private readonly ICollection<IVessel> models;

        public IReadOnlyCollection<IVessel> Models => (IReadOnlyCollection<IVessel>)models;

        public void Add(IVessel model)
        {
            this.models.Add(model);
        }

        public IVessel FindByName(string name)
        {
            return models.FirstOrDefault(x => x.Name == name);
        }

        public bool Remove(IVessel model)
        {
            return this.models.Remove(model);
        }
    }
}
