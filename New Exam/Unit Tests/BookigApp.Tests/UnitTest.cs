using FrontDeskApp;
using NUnit.Framework;
using System;

namespace BookigApp.Tests
{
    public class Tests
    {

        private Hotel hotel;

        [SetUp]
        public void Setup()
        {
            this.hotel = new Hotel("YG", 5);
        }

        [Test]
        public void Test1()
        {
            Assert.AreEqual("YG", this.hotel.FullName);
            Assert.AreEqual(5, this.hotel.Category);
            Assert.AreEqual(0, this.hotel.Turnover);
            Assert.AreEqual(0, this.hotel.Rooms.Count);
            Assert.AreEqual(0, this.hotel.Bookings.Count);
        }

        [TestCase(null,2)]
        [TestCase(" ",2)]
        public void TestHotelName(string name,int capacity)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                new Hotel(name, capacity);
            });
        }

        [TestCase("YG",-100)]
        [TestCase("YG",22)]
        public void TestHotelCategory(string name,int category)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                new Hotel(name, category);
            });
        }

        [Test]
        public void TestHotelAddRoom()
        {
            this.hotel.AddRoom(new Room(1, 100));
            Assert.AreEqual(1, this.hotel.Rooms.Count);
        }

        [Test]
        public void TestHotelBookRoom()
        {
            Assert.Throws<ArgumentException>(() => this.hotel.BookRoom(-22, 1, 1, 1));
            Assert.Throws<ArgumentException>(() => this.hotel.BookRoom(5, -1, 1, 1));
            Assert.Throws<ArgumentException>(() => this.hotel.BookRoom(5, 5, -18, 1));

            Room room = new Room(10, 25);
            this.hotel.AddRoom(room);

            this.hotel.BookRoom(1, 1, 1, 50);
            Assert.AreEqual(1, this.hotel.Bookings.Count);
            Assert.AreEqual(25, this.hotel.Turnover);
        }

    }
}