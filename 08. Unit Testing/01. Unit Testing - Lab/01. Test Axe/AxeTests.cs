using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {
        [Test]
        public void AxeLosesDurabilityAfterAttack()
        {
            //Arrange
            Axe axe = new Axe(10, 10);
            Dummy dummy = new Dummy(10, 10);

            //Act
            axe.Attack(dummy);

            //Assert
            Assert.That(axe.DurabilityPoints, Is.EqualTo(9), "Axe Durability doesn't change after attack.");
        }

        [Test]
        public void ThrowsExceptionWithBrokenWeapon()
        {
            //Arrange and Act
            Axe axe = new Axe(10, 0);
            Dummy dummy = new Dummy(10, 10);

            //Assert
            Assert.Throws<InvalidOperationException>(() => axe.Attack(dummy));
        }
    }
}