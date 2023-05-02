namespace Formula1.Repositories
{
    using Formula1.Models.Contracts;
    using Formula1.Repositories.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class PilotRepository : IRepository<IPilot>
    {
        private ICollection<IPilot> models;

        public PilotRepository()
        {
            this.models = new List<IPilot>();
        }
        public IReadOnlyCollection<IPilot> Models => (IReadOnlyCollection<IPilot>)models;

        public void Add(IPilot model)
        {
            models.Add(model);
        }

        public IPilot FindByName(string name)
        {
            var pilot = Models.FirstOrDefault(x => x.FullName == name);
            return pilot;
        }

        public bool Remove(IPilot model)
        {
            return models.Remove(model);
        }
    }
}
