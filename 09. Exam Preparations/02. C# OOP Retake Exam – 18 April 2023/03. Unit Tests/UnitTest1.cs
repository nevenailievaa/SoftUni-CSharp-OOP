using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace VehicleGarage.Tests
{
    public class Tests
    {
        //Fields
        private Garage garage;

        //Tests
        [SetUp]
        public void Setup()
        {
            garage = new Garage(3);
        }

        [Test]
        public void GarageConstructorShouldWorkCorrectly()
        {
            Type expectedType = typeof(List<Vehicle>);
            Type actualType = garage.Vehicles.GetType();

            //Assert
            Assert.IsNotNull(garage.Vehicles);
            Assert.AreEqual(3, garage.Capacity);
            Assert.AreSame(expectedType, actualType);

        }

        [Test]
        public void GarageAddVehicleShouldAddAVehicleToTheGarage()
        {
            //Arrange
            Vehicle vehicle = new Vehicle("Volkswagen", "Polo", "CB2404XA");

            //Assert
            Assert.IsTrue(garage.AddVehicle(vehicle));
            Assert.AreEqual(1, garage.Vehicles.Count);
        }

        [Test]
        public void GarageAddVehicleShouldReturnFalseWhenTryingToAddAVehicleWhenGarageIsFull()
        {
            //Arrange
            Vehicle vehicle = new Vehicle("Volkswagen", "Polo", "CB2404XA");
            Vehicle vehicleTwo = new Vehicle("Mercedes", "Benz", "PA2354TB");
            Vehicle vehicleThree = new Vehicle("Renault", "Clio", "CA2583KP");
            Vehicle vehicleFour = new Vehicle("Peugeot", "607", "PB8437HE");

            //Act
            garage.AddVehicle(vehicle);
            garage.AddVehicle(vehicleTwo);
            garage.AddVehicle(vehicleThree);

            //Assert
            Assert.IsFalse(garage.AddVehicle(vehicleFour));
            Assert.AreEqual(3, garage.Vehicles.Count);
        }

        [Test]
        public void GarageAddVehicleShouldReturnFalseWhenTryingToAddAVehicleWithTheSamePlateNumber()
        {
            //Arrange
            Vehicle vehicle = new Vehicle("Volkswagen", "Polo", "CB2404XA");
            Vehicle vehicleTwo = new Vehicle("Mercedes", "Benz", "CB2404XA");

            //Act
            garage.AddVehicle(vehicle);

            //Assert
            Assert.IsFalse(garage.AddVehicle(vehicleTwo));
            Assert.AreEqual(1, garage.Vehicles.Count);
        }

        [Test]
        public void GarageChargeVehiclesShouldReturnTheNumberChargedVehicles()
        {
            //Arrange
            Vehicle vehicleOne = new Vehicle("Volkswagen", "Polo", "CB2404XA");
            Vehicle vehicleTwo = new Vehicle("Mercedes", "Benz", "PA2354TB");
            Vehicle vehicleThree = new Vehicle("Renault", "Clio", "CA2583KP");

            //Act
            vehicleOne.BatteryLevel = 50;
            vehicleTwo.BatteryLevel = 49;
            vehicleThree.BatteryLevel = 77;

            garage.AddVehicle(vehicleOne);
            garage.AddVehicle(vehicleTwo);
            garage.AddVehicle(vehicleThree);

            //Assert
            Assert.AreEqual(2, garage.ChargeVehicles(50));
            Assert.AreEqual(100, vehicleOne.BatteryLevel);
            Assert.AreEqual(100, vehicleTwo.BatteryLevel);
            Assert.AreEqual(77, vehicleThree.BatteryLevel);
        }

        [Test]
        public void GarageDriveVehicleShouldDecreaseTheCarsBattery()
        {
            //Arrange
            Vehicle vehicle = new Vehicle("Volkswagen", "Polo", "CB2404XA");
            garage.AddVehicle(vehicle);

            //Act
            garage.DriveVehicle("CB2404XA", 20, false);

            //Assert
            Assert.AreEqual(80, vehicle.BatteryLevel);
        }

        [Test]
        public void GarageDriveVehicleShouldDamageTheCarIfAccidentHappened()
        {
            //Arrange
            Vehicle vehicle = new Vehicle("Volkswagen", "Polo", "CB2404XA");
            Vehicle vehicleTwo = new Vehicle("Mercedes", "Benz", "PA2354TB");
            garage.AddVehicle(vehicle);
            garage.AddVehicle(vehicleTwo);

            //Act
            garage.DriveVehicle("CB2404XA", 20, true);
            garage.DriveVehicle("PA2354TB", 20, false);

            //Assert
            Assert.AreEqual(80, vehicle.BatteryLevel);
            Assert.IsTrue(vehicle.IsDamaged);
            Assert.IsFalse(vehicleTwo.IsDamaged);
        }

        [Test]
        public void GarageDriveVehicleMethodShouldntDoAnythingWhenIsDamaged()
        {
            //Arrange
            Vehicle vehicle = new Vehicle("Volkswagen", "Polo", "CB2404XA");

            //Act
            garage.AddVehicle(vehicle);
            garage.DriveVehicle("CB2404XA", 20, true);
            garage.DriveVehicle("CB2404XA", 20, false);

            //Assert
            Assert.AreEqual(80, vehicle.BatteryLevel);
        }

        [Test]
        public void GarageDriveVehicleMethodShouldntDoAnythingWhenBatterydrainageIsOver100()
        {
            //Arrange
            Vehicle vehicle = new Vehicle("Mercedes", "Benz", "PA2354TB");

            //Act
            garage.AddVehicle(vehicle);
            garage.DriveVehicle("PA2354TB", 101, false);

            //Assert
            Assert.AreEqual(100, vehicle.BatteryLevel);
        }

        [Test]
        public void GarageDriveVehicleMethodShouldntDoAnythingWhenBatteryLevelIsLessThanBatteryDrainage()
        {
            //Arrange
            Vehicle vehicle = new Vehicle("Renault", "Clio", "CA2583KP");
            vehicle.BatteryLevel = 10;

            //Act
            garage.AddVehicle(vehicle);
            garage.DriveVehicle("CA2583KP", 11, false);

            //Assert
            Assert.AreEqual(10, vehicle.BatteryLevel);
        }

        [Test]
        public void GarageRepairVehiclesShouldReturnTheNumberRepairedVehicles()
        {
            //Arrange
            Vehicle vehicleOne = new Vehicle("Volkswagen", "Polo", "CB2404XA");
            Vehicle vehicleTwo = new Vehicle("Mercedes", "Benz", "PA2354TB");
            Vehicle vehicleThree = new Vehicle("Renault", "Clio", "CA2583KP");

            vehicleOne.IsDamaged = true;
            vehicleTwo.IsDamaged = false;
            vehicleThree.IsDamaged = true;

            garage.AddVehicle(vehicleOne);
            garage.AddVehicle(vehicleTwo);
            garage.AddVehicle(vehicleThree);

            //Assert
            Assert.AreEqual("Vehicles repaired: 2", garage.RepairVehicles());
            Assert.IsFalse(vehicleOne.IsDamaged);
            Assert.IsFalse(vehicleTwo.IsDamaged);
            Assert.IsFalse(vehicleThree.IsDamaged);
        }
    }
}