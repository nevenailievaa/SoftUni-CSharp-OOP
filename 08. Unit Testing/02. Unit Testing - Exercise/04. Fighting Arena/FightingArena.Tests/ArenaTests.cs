namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;

    [TestFixture]
    public class ArenaTests
    {
        private Arena arena;

        [SetUp]
        public void Setup()
        {
            arena = new Arena();
        }

        //CONSTRUCTOR
        [Test]
        public void ArenaConstructorShouldWorkProperly()
        {
            //Assert
            Assert.IsNotNull(arena);
            Assert.IsNotNull(arena.Warriors);
        }

        //COUNT PROPERTY
        [Test]
        public void ArenaCountShouldWorkCorrectly()
        {
            Warrior warrior = new Warrior("Gosho", 5, 100);

            arena.Enroll(warrior);

            Assert.IsNotEmpty(arena.Warriors);
            Assert.AreEqual(1, arena.Count);
        }

        //ENROLL METHOD
        [Test]
        public void ArenaEnrollMethodShouldWorkProperly()
        {
            //Arrange
            Warrior warrior = new Warrior("Achilles", 150, 1500);

            //Act
            arena.Enroll(warrior);

            //Assert
            Assert.IsNotEmpty(arena.Warriors);
            Assert.AreEqual(warrior, arena.Warriors.Single());
        }

        [Test]
        public void ArenaEnrollMethodShouldThrowAnExceptionIfThereIsAlreadyAWarriorWithTheSameName()
        {
            //Arrange
            Warrior warrior = new Warrior("Achilles", 150, 1500);

            //Act
            arena.Enroll(warrior);

            //Assert
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(()
                => arena.Enroll(warrior), "Warrior is already enrolled for the fights!");
        }


        //FIGHT METHOD
        [Test]
        public void ArenaFightMethodShouldWorkCorrectly()
        {
            //Arrange
            Warrior attacker = new Warrior("Achilles", 150, 1500);
            Warrior attacked = new Warrior("Hector", 100, 1000);

            //Act
            arena.Enroll(attacker);
            arena.Enroll(attacked);

            arena.Fight("Achilles", "Hector");

            //Assert
            Assert.AreEqual(attacker.HP, 1400);
            Assert.AreEqual(attacked.HP, 850);
        }

        [Test]
        public void ArenaFightMethodShouldThrowAnExceptionIfAttackerNameIsMissing()
        {
            //Arrange
            Warrior attacked = new Warrior("Hector", 100, 1000);

            //Act
            arena.Enroll(attacked);

            //Assert
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(()
                => arena.Fight("Elena", "Hector"), "There is no fighter with name Elena enrolled for the fights!");
        }

        [Test]
        public void ArenaFightMethodShouldThrowAnExceptionIfAttackedNameIsMissing()
        {
            //Arrange
            Warrior attacker = new Warrior("Achilles", 150, 1500);

            //Act
            arena.Enroll(attacker);

            //Assert
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(()
                => arena.Fight("Achilles", "Elena"), "There is no fighter with name Elena enrolled for the fights!");
        }

    }
}