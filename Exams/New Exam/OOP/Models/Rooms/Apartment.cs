namespace BookingApp.Models.Rooms
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Apartment : Room
    {
        private const int apartmentCapacity = 6;
        public Apartment() : base(apartmentCapacity)
        {
        }
    }
}
