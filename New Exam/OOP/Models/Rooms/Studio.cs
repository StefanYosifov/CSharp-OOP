namespace BookingApp.Models.Rooms
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Studio : Room
    {
        private const int studioCapacity = 4;
        public Studio() : base(studioCapacity)
        {
        }
    }
}
