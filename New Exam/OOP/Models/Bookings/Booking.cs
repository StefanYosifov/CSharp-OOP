namespace BookingApp.Models.Bookings
{
    using BookingApp.Models.Bookings.Contracts;
    using BookingApp.Models.Rooms.Contracts;
    using BookingApp.Utilities.Messages;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Booking : IBooking
    {
        private int redisdenceDuration;
        private int adultsCount;
        private int childrenCount;
        private int bookingNumber;
        private IRoom room;



        public Booking(IRoom room,int residenceDuration,int adultsCount,int childrenCount,int bookingNumber)
        {
            this.Room = room;
            this.ResidenceDuration = residenceDuration;
            this.AdultsCount = adultsCount;
            this.ChildrenCount = childrenCount;
            this.BookingNumber = bookingNumber;
        }

        public IRoom Room
        {
            get => this.room;
            private set
            {
                this.room = value;
            }
        }

        public int ResidenceDuration
        {
            get => this.redisdenceDuration;
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException(ExceptionMessages.DurationZeroOrLess);
                }
                this.redisdenceDuration = value;
            }
        }

        public int AdultsCount
        {
            get => this.adultsCount;
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException(ExceptionMessages.AdultsZeroOrLess);
                }
                this.adultsCount = value;
            }
        }

        public int ChildrenCount
        {
            get => this.childrenCount;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.ChildrenNegative);
                }
                this.childrenCount = value;
            }
        }

        public int BookingNumber
        {
            get => this.bookingNumber;
            private set
            {
                this.bookingNumber = value;
            }
        }

        public string BookingSummary()
        {
            double totalPaid = Math.Round(ResidenceDuration * Room.PricePerNight, 2);


            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Booking number: {BookingNumber}");
            sb.AppendLine($"Room type: {Room.GetType().Name}");
            sb.AppendLine($"Adults: {AdultsCount} Children: {ChildrenCount}");
            sb.AppendLine($"Total amount paid: {totalPaid:F2} $");
            return sb.ToString().TrimEnd();
        }
    }
}
