namespace BookingApp.Models.Rooms
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class DoubleBed : Room
    {
        private const int doubleBedCapacity = 2;

        public DoubleBed() : base(doubleBedCapacity)
        {
        }
    }
}
