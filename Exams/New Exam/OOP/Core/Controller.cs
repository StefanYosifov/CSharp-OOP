namespace BookingApp.Core
{
    using BookingApp.Core.Contracts;
    using BookingApp.Models.Bookings;
    using BookingApp.Models.Bookings.Contracts;
    using BookingApp.Models.Hotels;
    using BookingApp.Models.Hotels.Contacts;
    using BookingApp.Models.Rooms;
    using BookingApp.Models.Rooms.Contracts;
    using BookingApp.Repositories;
    using BookingApp.Utilities.Messages;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Controller : IController
    {
        private HotelRepository hotels;

        public Controller()
        {
            this.hotels = new HotelRepository();
        }

        public string AddHotel(string hotelName, int category)
        {
            IHotel hotel = hotels.Select(hotelName);
            if (hotel != null)
            {
                return string.Format(OutputMessages.HotelAlreadyRegistered, hotelName);
            }

            IHotel hotelToAdd = new Hotel(hotelName, category);
            hotels.AddNew(hotelToAdd);

            return string.Format(OutputMessages.HotelSuccessfullyRegistered, category, hotelName);
        }

        public string BookAvailableRoom(int adults, int children, int duration, int category)
        {
            
            int capacity = adults + children;
            IHotel hotelToFit = null;


            var orderedHotels = hotels.All().OrderBy(x => x.FullName);
            if (!orderedHotels.Any())
            {
                return $"{category} star hotel is not available in our platform.";
            }



            List<IRoom> rooms = new List<IRoom>();

            foreach(var hotel in orderedHotels)
            {
                foreach(var hotelRoom in hotel.Rooms.All())
                {
                    if (hotelRoom.PricePerNight > 0)
                    {
                        rooms.Add(hotelRoom);
                        hotelToFit = hotel;
                    }
                }
            }
            List<IRoom> finallyOrderedRooms = rooms.OrderBy(x => x.BedCapacity).ToList();

            

            IRoom finalRoom = finallyOrderedRooms.FirstOrDefault(x => x.BedCapacity==capacity);
            if (finalRoom == null)
            {
                return "We cannot offer appropriate room for your request.";
            }
           

            int finalRoomBookingNumber = hotelToFit.Bookings.All().Count + 1;
            IBooking booking = new Booking(finalRoom, duration, adults, children, finalRoomBookingNumber);

            hotelToFit.Bookings.AddNew(booking);
            return $"Booking number {finalRoomBookingNumber} for {hotelToFit.FullName} hotel is successful!";


        }

        public string HotelReport(string hotelName)
        {
            if (this.hotels.Select(hotelName) == null)
            {
                return $"Profile {hotelName} doesn’t exist!";
            }

            IHotel hotel = this.hotels.Select(hotelName);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Hotel name: {hotelName}");
            sb.AppendLine($"--{hotel.Category} star hotel");
            sb.AppendLine($"--Turnover: {hotel.Turnover:F2} $"); 
            sb.AppendLine($"--Bookings:");
            sb.AppendLine();

            if(hotel.Bookings.All().Any())
            {
                foreach (var book in hotel.Bookings.All())
                {
                    sb.AppendLine(book.BookingSummary());
                    sb.AppendLine();
                }
            }
            else
            {
                sb.AppendLine("none");
            }

            return sb.ToString().TrimEnd();
        }

        public string SetRoomPrices(string hotelName, string roomTypeName, double price)
        {
            IHotel hotelToCheck=hotels.Select(hotelName);
            if (hotelToCheck == null)
            {
                return string.Format(OutputMessages.HotelNameInvalid, hotelName);
            }

           

            if (roomTypeName != nameof(Studio)
                && roomTypeName != nameof(DoubleBed)
                && roomTypeName != nameof(Apartment))
            {
                throw new ArgumentException("Incorrect room type!");
            }
           


            IRoom room = hotelToCheck.Rooms.Select(roomTypeName);
            if(room == null)
            {
                return OutputMessages.RoomTypeNotCreated;
            }
            if (room.PricePerNight != 0)
            {
                throw new InvalidOperationException(ExceptionMessages.PriceAlreadySet);
            }

            room.SetPrice(price);
            return string.Format(OutputMessages.PriceSetSuccessfully, roomTypeName, hotelName);
        }

        public string UploadRoomTypes(string hotelName, string roomTypeName)
        {
            IHotel hotelToCheck = hotels.Select(hotelName);
            if (hotelToCheck == null)
            {
                return String.Format(OutputMessages.HotelNameInvalid, hotelName);
            }
            if (hotelToCheck.Rooms.Select(roomTypeName)!=null)
            {
                return OutputMessages.RoomTypeAlreadyCreated;
            }


           


            IRoom room=null;
            if (roomTypeName == nameof(DoubleBed))
            {
                room=new DoubleBed();
            }
            else if (roomTypeName == nameof(Apartment))
            {
                room = new Apartment();
            }
            else if (roomTypeName == nameof(Studio))
            {
                room = new Studio();
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.RoomTypeIncorrect);
            }

            hotelToCheck.Rooms.AddNew(room);
            return $"Successfully added {roomTypeName} room type in {hotelName} hotel!";
        }
    }
}
