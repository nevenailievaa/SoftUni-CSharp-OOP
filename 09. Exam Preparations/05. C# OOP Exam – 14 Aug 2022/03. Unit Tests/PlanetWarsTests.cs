using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Numerics;

namespace PlanetWars.Tests
{
    public class Tests
    {
        [TestFixture]
        public class PlanetWarsTests
        {
            //Fields
            private Weapon weapon;
            private Planet planet;

            [SetUp]
            public void StartUp()
            {
                weapon = new Weapon("AK-47", 4.700, 10);
                planet = new Planet("Uranus", 10);

            }

            //WEAPON TESTS
            [Test]
            public void WeaponConstructorShouldWorkProperly()
            {
                Assert.IsNotNull(weapon);
                Assert.AreEqual("AK-47", weapon.Name);
                Assert.AreEqual(4.700, weapon.Price);
                Assert.AreEqual(10, weapon.DestructionLevel);
            }

            [Test]
            public void WeaponPriceFieldShouldThrowArgumentExceptionIfNegative()
            {
                Assert.Throws<ArgumentException>(()
                    => weapon.Price = -1);
            }

            [Test]
            public void WeaponIncreaseDestructionLevelMethodShouldWorkProperly()
            {
                weapon.IncreaseDestructionLevel();
                Assert.AreEqual(11, weapon.DestructionLevel);
            }

            [Test]
            public void WeaponIsNuclearPropertyShouldSetToTrueIfValueIsBiggerOrEqualTo10()
            {
                weapon.DestructionLevel = 9;
                Assert.IsFalse(weapon.IsNuclear);

                weapon.IncreaseDestructionLevel();
                Assert.IsTrue(weapon.IsNuclear);

                weapon.IncreaseDestructionLevel();
                Assert.IsTrue(weapon.IsNuclear);
            }

            //PLANET TESTS
            [Test]
            public void PlanetConstructorShouldWorkProperly()
            {
                Assert.IsNotNull(planet);
                Assert.AreEqual("Uranus", planet.Name);
                Assert.AreEqual(10, planet.Budget);
                Assert.IsNotNull(planet.Weapons);
                Assert.That(planet.Weapons.GetType() == typeof(List<Weapon>));
            }

            [TestCase(null)]
            [TestCase("")]
            public void PlanetNamePropertyShouldThrowAnArgumentExceptionIfSetToNullOrEmpty(string value)
            {
                Assert.Throws<ArgumentException>(()
                    => planet = new Planet(value, 10), "Invalid planet Name");
            }

            [TestCase(-1)]
            [TestCase(-10)]
            public void PlanetNamePropertyShouldThrowAnArgumentExceptionIfSetToNullOrEmpty(double value)
            {
                Assert.Throws<ArgumentException>(()
                    => planet = new Planet("AK-47", value), "Budget cannot drop below Zero!");
            }

            [Test]
            public void PlanetMilitaryPowerRatioPropertyShouldCalculateProperly()
            {
                planet.AddWeapon(new Weapon("Bazooka", 10000, 90));
                planet.AddWeapon(new Weapon("Bazooka2", 20000, 180));

                Assert.AreEqual(270, planet.MilitaryPowerRatio);
            }

            [Test]
            public void PlanetProfitMethodShouldCalculateProperly()
            {
                planet.Profit(90);
                Assert.AreEqual(100, planet.Budget);
            }

            [Test]
            public void PlanetSpendFundsMethodShouldCalculateProperly()
            {
                planet.SpendFunds(10);
                Assert.AreEqual(0, planet.Budget);

                Assert.Throws<InvalidOperationException>(()
                    => planet.SpendFunds(1), "Not enough funds to finalize the deal.");
            }

            [Test]
            public void PlanetAddWeaponMethodShouldWorkProperly()
            {
                planet.AddWeapon(new Weapon("Bazooka", 10000, 90));
                Assert.IsTrue(planet.Weapons.Count == 1);
                Assert.IsTrue(planet.Weapons.Any(p => p.Name == "Bazooka" && p.Price == 10000 && p.DestructionLevel == 90));

                Assert.Throws<InvalidOperationException>(()
                    => planet.AddWeapon(new Weapon("Bazooka", 10000, 90)), $"There is already a Bazooka weapon.");
            }

            [Test]
            public void PlanetRemoveWeaponMethodShouldRemoveTheSearchedWeapon()
            {
                planet.AddWeapon(new Weapon("Bazooka", 10000, 90));
                planet.AddWeapon(new Weapon("Bazooka2", 20000, 180));
                planet.RemoveWeapon("Bazooka");
                planet.RemoveWeapon("Bazooka");

                Assert.That(planet.Weapons.Count == 1);
            }

            [Test]
            public void PlanetUpgradeWeaponMethodShouldWorkProperly()
            {
                Weapon weaponOne = new Weapon("Bazooka", 10000, 5);
                Weapon weaponTwo = new Weapon("Bazooka2", 20000, 10);
                planet.AddWeapon(weaponOne);
                planet.AddWeapon(weaponTwo);

                planet.UpgradeWeapon("Bazooka");
                Assert.AreEqual(weaponOne.DestructionLevel, 6);
                Assert.AreEqual(weaponTwo.DestructionLevel, 10);

                Assert.Throws<InvalidOperationException>(()
                    => planet.UpgradeWeapon("Bazooka3"), $"Bazooka3 does not exist in the weapon repository of {planet.Name}");
                Assert.AreEqual(weaponOne.DestructionLevel, 6);
                Assert.AreEqual(weaponTwo.DestructionLevel, 10);
            }

            [TestCase(10)]
            [TestCase(11)]
            public void PlanetDestructOpponentMethodShouldWorkProperly(int destructionLevel)
            {
                Planet planetTwo = new Planet("Venus", 100);
                Planet planetThree = new Planet("Earth", 100);

                planet.AddWeapon(new Weapon("Bazooka", 10000, 10));
                planetTwo.AddWeapon(new Weapon("Bazooka", 10000, 5));
                planetThree.AddWeapon(new Weapon("Bazooka", 10000, destructionLevel));

                Assert.AreEqual("Venus is destructed!", planet.DestructOpponent(planetTwo));
                Assert.Throws<InvalidOperationException>(()
                    => planet.DestructOpponent(planetThree), "Earth is too strong to declare war to!");
            }
        }
    }
}