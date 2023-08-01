using FrontDeskApp;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookigApp.Tests
{
    public class Tests
    {
        //Fields
        private Hotel hotel;

        //TESTS
        [SetUp]
        public void Setup()
        {
            hotel = new Hotel("Trump", 5);
        }

        [Test]
        public void HotelConstructorShouldWorkProperly()
        {
            Assert.IsNotNull(hotel);
            Assert.AreEqual(hotel.FullName, "Trump");
            Assert.AreEqual(hotel.Category, 5);
            Assert.AreEqual(hotel.Turnover, 0);
            Assert.IsNotNull(hotel.Rooms);
            Assert.IsNotNull(hotel.Bookings);
            Assert.AreEqual(hotel.Rooms.GetType(), typeof(List<Room>));
            Assert.AreEqual(hotel.Bookings.GetType(), typeof(List<Booking>));
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase("     ")]
        public void HotelFullNamePropertyShouldThrowAnArgumentNullExceptionIfNullOrWhiteSpace(string name)
        {
            Assert.Throws<ArgumentNullException>(()
                => hotel = new Hotel(name, 5));
        }

        [TestCase(0)]
        [TestCase(6)]
        public void HotelCategoryPropertyShouldThrowAnArgumentExceptionIfLessThanOneOrMoreThanFive(int value)
        {
            Assert.Throws<ArgumentException>(()
                => hotel = new Hotel("Trump", value));
        }

        [Test]
        public void HotelAddRoomMethodShouldAddRoom()
        {
            hotel.AddRoom(new Room(2, 50));
            Assert.AreEqual(1, hotel.Rooms.Count);
        }

        [Test]
        public void HotelBookRoomMethodShouldThrowTheCorrectExceptions()
        {
            //If Adults <= 0
            Assert.Throws<ArgumentException>(()
                => hotel.BookRoom(-1, 2, 7, 1000));

            Assert.Throws<ArgumentException>(()
                => hotel.BookRoom(0, 2, 7, 1000));

            //If Children < 0
            Assert.Throws<ArgumentException>(()
                => hotel.BookRoom(2, -1, 7, 1000));

            //If Residence Duration < 1
            Assert.Throws<ArgumentException>(()
                => hotel.BookRoom(2, 2, 0, 1000));
        }

        [Test]
        public void HotelBookRoomMethodShouldWorkProperly()
        {
            hotel.AddRoom(new Room(1, 100));
            hotel.AddRoom(new Room(2, 150));
            hotel.AddRoom(new Room(5, 300));

            Assert.AreEqual(hotel.Bookings.Count, 0);
            Assert.AreEqual(hotel.Turnover, 0);

            //No Enough Beds Available
            hotel.BookRoom(3, 3, 7, 10000);
            Assert.AreEqual(hotel.Bookings.Count, 0);
            Assert.AreEqual(hotel.Turnover, 0);

            //Not Enough Money
            hotel.BookRoom(2, 3, 7, 2099);
            Assert.AreEqual(hotel.Bookings.Count, 0);
            Assert.AreEqual(hotel.Turnover, 0);

            //Reservation Made
            hotel.BookRoom(2, 3, 7, 2100);
            Assert.AreEqual(hotel.Bookings.Count, 1);
            Assert.AreEqual(hotel.Turnover, 2100);
        }
    }
}