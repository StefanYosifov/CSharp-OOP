namespace BookingApp.Repositories
{
    using BookingApp.Models.Rooms.Contracts;
    using BookingApp.Repositories.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class RoomRepository : IRepository<IRoom>
    {
        private List<IRoom> models;

        public RoomRepository()
        {
            this.models=new List<IRoom>();
        }

       

        public void AddNew(IRoom model)
        {
            this.models.Add(model);
        }

        public IReadOnlyCollection<IRoom> All()
        {
            return models as IReadOnlyCollection<IRoom>;
        }

        public IRoom Select(string criteria)
        {
            var room = models.FirstOrDefault(x =>x.GetType().Name == criteria);
            return room;
        }
    }
}
