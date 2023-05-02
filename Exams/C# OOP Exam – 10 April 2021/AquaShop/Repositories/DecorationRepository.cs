namespace AquaShop.Repositories
{
    using AquaShop.Models.Decorations.Contracts;
    using AquaShop.Repositories.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class DecorationRepository : IRepository<IDecoration>
    {

        private ICollection<IDecoration> models;

        public IReadOnlyCollection<IDecoration> Models => models as IReadOnlyCollection<IDecoration>;

        public void Add(IDecoration model)
        {
            this.models.Add(model);
        }

        public IDecoration FindByType(string type)
        {
            IDecoration decoration = Models.FirstOrDefault(x=>x.GetType().Name==type);
            return decoration;
        }

        public bool Remove(IDecoration model)
        {
            return this.models.Remove(model);
        }
    }
}
