namespace BookingApp.Models.Rooms
{
    using BookingApp.Models.Rooms.Contracts;
    using BookingApp.Utilities.Messages;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public abstract class Room : IRoom
    {
        private int bedCapacity;
        private double pricePerNight;


        public Room(int bedCapacity)
        {
            this.BedCapacity = bedCapacity;
            this.PricePerNight = 0;
        }

        public int BedCapacity
        {
            get => this.bedCapacity;
            private set
            {
                this.bedCapacity = value;
            }
        }


        public double PricePerNight
        {
            get => this.pricePerNight;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.PricePerNightNegative);
                }
                this.pricePerNight = value;
            }
        }

        public virtual void SetPrice(double price)
        {
            if (price < 0)
            {
                throw new ArgumentException(ExceptionMessages.PricePerNightNegative);
            }
            this.pricePerNight = price;
        }
    }
}
