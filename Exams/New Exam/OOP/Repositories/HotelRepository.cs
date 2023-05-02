namespace BookingApp.Repositories
{
    using BookingApp.Models.Hotels.Contacts;
    using BookingApp.Repositories.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class HotelRepository : IRepository<IHotel>
    {
        private List<IHotel> models;

        public HotelRepository()
        {
            this.models = new List<IHotel>();
        }

      

        public void AddNew(IHotel model)
        {
            this.models.Add(model);
        }

        public IReadOnlyCollection<IHotel> All()
        {
            return this.models as IReadOnlyCollection<IHotel>;
        }

        public IHotel Select(string criteria)
        {
            return models.FirstOrDefault(x => x.FullName == criteria);
        }
    }
}
