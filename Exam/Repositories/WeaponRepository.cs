namespace PlanetWars.Repositories
{
    using PlanetWars.Models.Weapons.Contracts;
    using PlanetWars.Repositories.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class WeaponRepository : IRepository<IWeapon>
    {
        private readonly ICollection<IWeapon> models;

        public WeaponRepository()
        {
            this.models = new List<IWeapon>();
        }

        public IReadOnlyCollection<IWeapon> Models => this.models as IReadOnlyCollection<IWeapon>;

        public void AddItem(IWeapon model)
        {
            this.models.Add(model); 
        }

        public IWeapon FindByName(string name)
        {
            return Models.FirstOrDefault(x => x.GetType().Name == name);
        }

        public bool RemoveItem(string name)
        {
            var ItemToRemove=this.models.FirstOrDefault(x => x.GetType().Name == name);
            return this.models.Remove(ItemToRemove);
        }
    }
}
