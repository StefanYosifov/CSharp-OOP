namespace BookingApp.Models.Hotels
{
    using BookingApp.Models.Bookings.Contracts;
    using BookingApp.Models.Hotels.Contacts;
    using BookingApp.Models.Rooms.Contracts;
    using BookingApp.Repositories;
    using BookingApp.Repositories.Contracts;
    using System.Linq;
    using BookingApp.Models.Rooms;
    using System;
    using BookingApp.Utilities.Messages;

    public class Hotel : IHotel
    {
        private string fullName;
        private int category;
        private IRepository<IRoom> rooms;
        private IRepository<IBooking> bookings;

        public Hotel(string fullName,int category)
        {
            this.FullName = fullName;
            this.Category = category;
            this.rooms = new RoomRepository();
            this.bookings = new BookingRepository();
        }


        public string FullName
        {
            get => this.fullName;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.HotelNameNullOrEmpty);
                }
                this.fullName = value;
            }
        }

        public int Category
        {
            get => this.category;
            private set
            {
                if (value<1 || value>5)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidCategory);
                }
                this.category = value;
            }
        }

        public double Turnover//////////////////////////////////
        {
            get => CalculateTurnOver();
        }
        public IRepository<IRoom> Rooms { get => this.rooms; set => this.rooms=value; }
        public IRepository<IBooking> Bookings { get => this.bookings; set => this.bookings=value; }

        private double CalculateTurnOver() ////////
        {
            



            double sum = this.Bookings.All().Sum(x => x.ResidenceDuration * x.Room.PricePerNight);

            return Math.Round(sum, 2);

          
        }
    }
}
