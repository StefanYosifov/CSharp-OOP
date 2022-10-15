namespace BookingApp.Repositories
{
    using BookingApp.Models.Bookings.Contracts;
    using BookingApp.Repositories.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class BookingRepository : IRepository<IBooking>
    {
        private List<IBooking> models;


        public BookingRepository()
        {
            this.models=new List<IBooking>();   
        }
        public void AddNew(IBooking model)
        {
           this.models.Add(model);  
        }

        public IReadOnlyCollection<IBooking> All()
        {
            return this.models as IReadOnlyCollection<IBooking>;
        }

        public IBooking Select(string criteria)
        {
            return models.FirstOrDefault(x => x.BookingNumber.ToString() == criteria);
        }
    }
}
