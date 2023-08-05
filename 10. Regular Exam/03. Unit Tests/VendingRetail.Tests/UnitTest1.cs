using NUnit.Framework;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml.Linq;

namespace VendingRetail.Tests
{
    public class Tests
    {
        //Fields
        private CoffeeMat coffeeMat;

        [SetUp]
        public void Setup()
        {
            coffeeMat = new CoffeeMat(3, 2);
        }

        [Test]
        public void ConstructorTest()
        {
            Assert.IsNotNull(coffeeMat);
            Assert.AreEqual(coffeeMat.WaterCapacity, 3);
            Assert.AreEqual(coffeeMat.ButtonsCount, 2);
            Assert.AreEqual(coffeeMat.Income, 0);
        }

        [Test]
        public void FillWaterTankMethodTest()
        {
            //Filling The Tank
            Assert.AreEqual("Water tank is filled with 3ml", coffeeMat.FillWaterTank());

            //Not Enough Space To Fill The Tank
            Assert.AreEqual("Water tank is already full!", coffeeMat.FillWaterTank());
        }

        [Test]
        public void AddDrinkMethodTest()
        {
            //Adding A Drink
            Assert.IsTrue(coffeeMat.AddDrink("Hot Chocolate", 1.50));

            //Adding The Same Drink
            Assert.IsFalse(coffeeMat.AddDrink("Hot Chocolate", 1.50));

            //Not Enough Capacity
            coffeeMat.AddDrink("Milk Chocolate", 1.50);
            Assert.IsFalse(coffeeMat.AddDrink("Coffee", 1.00));
        }

        [Test]
        public void BuyDrinkMethodTest()
        {
            //Tank Level Under 80
            coffeeMat = new CoffeeMat(80, 2);
            coffeeMat.AddDrink("Hot Chocolate", 1.50);
            Assert.AreEqual("CoffeeMat is out of water!", coffeeMat.BuyDrink("Hot Chocolate"));

            //Not An Existing Drink
            coffeeMat.FillWaterTank();
            Assert.AreEqual("Milk Chocolate is not available!", coffeeMat.BuyDrink("Milk Chocolate"));

            //Buying A Drink
            Assert.AreEqual("Your bill is 1.50$", coffeeMat.BuyDrink("Hot Chocolate"));
            Assert.AreEqual(coffeeMat.BuyDrink("Milk"), "CoffeeMat is out of water!");
            Assert.AreEqual(coffeeMat.Income, 1.5);
        }

        [Test]
        public void CollectIncomeTest()
        {
            coffeeMat = new CoffeeMat(80, 2);
            coffeeMat.FillWaterTank();
            coffeeMat.AddDrink("Hot Chocolate", 1.50);
            coffeeMat.BuyDrink("Hot Chocolate");

            Assert.AreEqual(coffeeMat.CollectIncome(), 1.50);
            Assert.AreEqual(coffeeMat.Income, 0);
        }
    }
}