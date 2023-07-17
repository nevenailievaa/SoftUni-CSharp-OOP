namespace CarManager.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class CarManagerTests
    {
        private Car car;

        [SetUp]
        public void Setup()
        {
            car = new Car("Mercedes", "E250", 10, 100);
        }

        [Test]
        public void CarShouldBeCreatedSuccessfully()
        {
            //Arrange
            string expectedMake = "Mercedes";
            string expectedModel = "E250";
            double expectedFuelConsumption = 10;
            double expectedFuelCapacity = 100;

            //Assert
            Assert.AreEqual(expectedMake, car.Make);
            Assert.AreEqual(expectedModel, car.Model);
            Assert.AreEqual(expectedFuelConsumption, car.FuelConsumption);
            Assert.AreEqual(expectedFuelCapacity, car.FuelCapacity);
        }

        [Test]
        public void CarShouldBeCreatedWithZeroFuelAmount()
        {
            //Assert
            Assert.AreEqual(0, car.FuelAmount);
        }

        [TestCase(null)]
        [TestCase("")]
        public void CarMakeShouldntBeNullOrEmpty(string make)
        {
            //Assert
            ArgumentException exception = Assert.Throws<ArgumentException>(()
                => car = new Car(make, "E250", 10, 100));

            Assert.AreEqual("Make cannot be null or empty!", exception.Message);
        }

        [TestCase(null)]
        [TestCase("")]
        public void CarModelShouldntBeNullOrEmpty(string model)
        {
            //Assert
            ArgumentException exception = Assert.Throws<ArgumentException>(()
                => car = new Car("Mercedes", model, 10, 100));

            Assert.AreEqual("Model cannot be null or empty!", exception.Message);
        }

        [TestCase(0)]
        [TestCase(-1)]
        public void CarFuelConsumptionCannotBeZeroOrNegative(double fuelConsumption)
        {
            //Assert
            ArgumentException exception = Assert.Throws<ArgumentException>(()
                => car = new Car("Mercedes", "E250", fuelConsumption, 100));

            Assert.AreEqual("Fuel consumption cannot be zero or negative!", exception.Message);
        }

        [Test]
        public void CarFuelAmountCannotBeNegative()
        {
            //Assert
            Assert.Throws<InvalidOperationException>(()
            => car.Drive(1), "Fuel amount cannot be negative!");
        }

        [TestCase(0)]
        [TestCase(-1)]
        public void CarFuelCapacityCannotBeZeroOrNegative(double fuelCapacity)
        {
            //Assert
            ArgumentException exception = Assert.Throws<ArgumentException>(()
                => car = new Car("Mercedes", "E250", 10, fuelCapacity));

            Assert.AreEqual("Fuel capacity cannot be zero or negative!", exception.Message);
        }

        [TestCase(0)]
        [TestCase(-10)]
        public void CarRefuelMethodsFuelShouldNotBeZeroOrNegative(double fuel)
        {
            //Assert
            ArgumentException exception = Assert.Throws<ArgumentException>(()
                => car.Refuel(fuel));

            Assert.AreEqual("Fuel amount cannot be zero or negative!", exception.Message);
        }

        [Test]
        public void CarFuelAmountShouldNotBeMoreThanFuelCapacity()
        {
            //Arrange
            int expectedResult = 100;

            //Act
            car.Refuel(110);
            double actualResult = car.FuelAmount;

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void CarRefuelShouldWorkProperly()
        {
            //Arrange
            int expectedResult = 10;

            //Act
            car.Refuel(10);
            double actualResult = car.FuelAmount;

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase(100)]
        [TestCase(900)]
        public void CarDriveMethodShouldWorkProperly(double distance)
        {
            //Assert
            double fuelNeeded = (distance / 100) * car.FuelConsumption;

            //Act
            car.Refuel(100);
            car.Drive(distance);

            //Assert
            Assert.AreEqual(car.FuelAmount, 100 - fuelNeeded);
        }

        [Test]
        public void CarDriveMethodShouldThrowAnExceptionIfFuelIsNotEnough()
        {
            //Act
            car.Refuel(100);

            //Assert
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(()
                => car.Drive(1001));

            Assert.AreEqual("You don't have enough fuel to drive!", exception.Message);
        }
    }
}