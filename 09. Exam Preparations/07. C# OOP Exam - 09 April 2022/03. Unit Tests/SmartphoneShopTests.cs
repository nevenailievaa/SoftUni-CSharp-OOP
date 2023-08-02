using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace SmartphoneShop.Tests
{
    [TestFixture]
    public class SmartphoneShopTests
    {
        //Fields
        private Shop shop;

        //TESTS
        [SetUp]
        public void SetUp()
        {
            shop = new Shop(3);
        }

        [Test]
        public void ConstructorShouldWorkCorrectly()
        {
            Assert.IsNotNull(shop);
            Assert.AreEqual(3, shop.Capacity);
            Assert.AreEqual(0, shop.Count);
        }

        [Test]
        public void CapacityShouldThrowAnArgumentExceptionIfLessThanZero()
        {
            Assert.Throws<ArgumentException>(()
                => shop = new Shop(-1), "Invalid capacity.");
        }

        [Test]
        public void AddMethodShouldWorkCorrectly()
        {
            shop = new Shop(2);
            Smartphone phoneOne = new Smartphone("Iphone", 100);
            shop.Add(phoneOne);

            //Successfully Adding A Phone
            Assert.AreEqual(shop.Count, 1);

            //Already Existing Phone
            Assert.Throws<InvalidOperationException>(()
                => shop.Add(phoneOne), "The phone model Iphone 13 already exist.");

            //No Space For More Smartphones
            Smartphone phoneTwo = new Smartphone("Samsung", 100);
            Smartphone phoneThree = new Smartphone("Huawei", 100);
            shop.Add(phoneTwo);

            Assert.Throws<InvalidOperationException>(()
                => shop.Add(phoneThree), "The shop is full.");
        }

        [Test]
        public void RemoveMethodShouldWorkCorrectly()
        {
            Smartphone phoneOne = new Smartphone("Iphone", 100);
            Smartphone phoneTwo = new Smartphone("Samsung", 100);
            shop.Add(phoneOne);

            //Not An Existing Phone
            Assert.Throws<InvalidOperationException>(()
                => shop.Remove("Samsung"), "The phone model Samsung doesn't exist.");

            //Successfull Remove
            shop.Remove("Iphone");
            Assert.AreEqual(0, shop.Count);
        }

        [Test]
        public void TestPhoneMethodShouldWorkCorrectly()
        {
            Smartphone phoneOne = new Smartphone("Iphone", 100);
            Smartphone phoneTwo = new Smartphone("Samsung", 100);
            shop.Add(phoneOne);

            //Not An Existing Phone
            Assert.Throws<InvalidOperationException>(()
                => shop.TestPhone("Samsung", 20), "The phone model Samsung doesn't exist.");

            //Too Low Battery To Test
            Assert.Throws<InvalidOperationException>(()
                => shop.TestPhone("Iphone", 101), "The phone model Iphone is low on batery.");

            shop.TestPhone("Iphone", 90);

            Assert.AreEqual(10, phoneOne.CurrentBateryCharge);
        }


        [Test]
        public void ChargePhoneMethodShouldWorkCorrectly()
        {
            Smartphone phoneOne = new Smartphone("Iphone", 100);
            Smartphone phoneTwo = new Smartphone("Samsung", 100);
            shop.Add(phoneOne);
            shop.TestPhone("Iphone", 90);

            //Not An Existing Phone
            Assert.Throws<InvalidOperationException>(()
                => shop.ChargePhone("Samsung"), "The phone model Samsung doesn't exist.");

            //Battery Charged Successfully
            shop.ChargePhone("Iphone");
            Assert.AreEqual(100, phoneOne.CurrentBateryCharge);
        }
    }
}