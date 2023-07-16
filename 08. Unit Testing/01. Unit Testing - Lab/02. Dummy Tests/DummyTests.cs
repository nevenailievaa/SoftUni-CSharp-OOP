using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        [Test]
        public void DummyShouldInitializeWithCorrectValues()
        {
            //Arrange and Act
            Dummy dummy = new Dummy(100, 100);

            //Assert
            Assert.AreEqual(100, dummy.Health);
        }

        [Test]
        public void TakeAttackShouldDecreaseHealth()
        {
            //Arrange
            Dummy dummy = new Dummy(110, 100);

            //Act
            dummy.TakeAttack(10);

            //Assert
            Assert.AreEqual(100, dummy.Health);
        }

        [Test]
        public void TakeAttackShouldThrowExceptionIfDummyIsDead()
        {
            //Arrange
            Dummy dummy = new Dummy(100, 100);

            //Act
            dummy.TakeAttack(100);

            //Assert
            Assert.Throws<InvalidOperationException>(
                () => dummy.TakeAttack(100),
                "Dummy is dead.");
        }

        [Test]
        public void DeadDummyCanGiveExperience()
        {
            //Arrange
            Dummy dummy = new Dummy(100, 100);

            //Act
            dummy.TakeAttack(100);

            //Assert
            Assert.AreEqual(100, dummy.GiveExperience());
        }

        [Test]
        public void GiveXPShouldThrowAnExceptionIfDummyIsNotDead()
        {
            //Arrange
            Dummy dummy = new Dummy(100, 100);

            //Act
            dummy.TakeAttack(99);

            //Assert
            Assert.Throws<InvalidOperationException>(
                () => dummy.GiveExperience(),
                "Target is not dead.");
        }

        [Test]
        public void IsDeadShouldCheckIfHealthIsBelowOrEqualToZero()
        {
            //Arrange
            Dummy dummy = new Dummy(100, 100);
            Dummy dummyTwo = new Dummy(100, 100);

            //Act
            dummy.TakeAttack(99);
            dummyTwo.TakeAttack(100);

            //Assert
            Assert.IsFalse(dummy.IsDead());
            Assert.IsTrue(dummyTwo.IsDead());
        }
    }
}