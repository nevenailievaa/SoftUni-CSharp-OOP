namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class WarriorTests
    {
        private Warrior warrior;

        [SetUp]
        public void Setup()
        {
            warrior = new Warrior("Naruto", 10, 100);
        }


        //WARRIOR CONSTRUCTOR
        [Test]
        public void WarriorConstructorShouldWorkProperly()
        {
            //Arrange
            string expectedName = "Naruto";
            int expectedDamage = 10;
            int expectedHP = 100;

            //Assert
            Assert.AreEqual(expectedName, warrior.Name);
            Assert.AreEqual(expectedDamage, warrior.Damage);
            Assert.AreEqual(expectedHP, warrior.HP);
        }


        //WARRIOR NAME
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase("      ")]
        public void WarriorNameShouldThrowAnExceptionIfItsEmptyOrWhitespace(string name)
        {
            //Assert
            ArgumentException exception = Assert.Throws<ArgumentException>(()
                => warrior = new Warrior(name, 10, 100), "Name should not be empty or whitespace!");
        }
        

        //WARRIOR DAMAGE
        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-20)]
        public void WarriorDamageShouldThrowAnExceptionIfItsZeroOrNegative(int damage)
        {
            //Assert
            ArgumentException exception = Assert.Throws<ArgumentException>(()
                => warrior = new Warrior("Naruto", damage, 100), "Damage value should be positive!");
        }

        
        //WARRIOR HP
        [TestCase(-1)]
        [TestCase(-20)]
        public void WarriorHpShouldThrowAnExceptionIfItsNegative(int hp)
        {
            //Assert
            ArgumentException exception = Assert.Throws<ArgumentException>(()
                => warrior = new Warrior("Naruto", 10, hp), "HP should not be negative!");
        }


        //WARRIOR ATTACK METHOD
        [TestCase(100)]
        [TestCase(50)]
        [TestCase(31)]
        public void WarriorAttackMethodShouldWorkCorrectly(int hp)
        {
            //Arrange
            int expectedAtackerHp = 95;
            int expectedDefenderHp = 80;

            //Act
            Warrior attacker = new Warrior("Pesho", 10, 100);
            Warrior defender = new Warrior("Gosho", 5, 90);

            attacker.Attack(defender);

            //Assert
            Assert.AreEqual(expectedAtackerHp, attacker.HP);
            Assert.AreEqual(expectedDefenderHp, defender.HP);
        }

        [TestCase(30)]
        [TestCase(29)]
        [TestCase(10)]
        public void WarriorAttackMethodShouldThrowAnExceptionIfHisHpIsLessOrEqualThanTheMinimumAttackHp(int hp)
        {
            //Arrange
            Warrior warriorAttacker = new Warrior("Naruto", 10, hp);
            Warrior warriorAttacked = new Warrior("Naruto", 10, 100);

            //Assert
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(()
                => warriorAttacker.Attack(warriorAttacked), "Your HP is too low in order to attack other warriors!");

        }

        [TestCase(30)]
        [TestCase(29)]
        [TestCase(10)]
        public void WarriorAttackMethodShouldThrowAnExceptionIfAttackedWarriorsHpIsLessOrEqualThanTheMinimumAttackHp(int hp)
        {
            //Arrange
            Warrior warriorAttacker = new Warrior("Naruto", 10, 100);
            Warrior warriorAttacked = new Warrior("Naruto", 10, hp);

            //Assert
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(()
                => warriorAttacker.Attack(warriorAttacked), "Enemy HP must be greater than 30 in order to attack him!");
        }

        [Test]
        public void WarriorAttackMethodShouldThrowAnExceptionIfEnemyDamageIsMoreThanWarriorHp()
        {
            //Arrange
            Warrior warriorAttacker = new Warrior("Naruto", 10, 100);
            Warrior warriorAttacked = new Warrior("Naruto", 110, 100);

            //Assert
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(()
                => warriorAttacker.Attack(warriorAttacked), "You are trying to attack too strong enemy");
        }

        [Test]
        public void WarriorAttackMethodShouldDecreaseEnemysHealthToZeroIfHisDamageIsMoreThanIt()
        {
            //Arrange
            Warrior warriorAttacker = new Warrior("Naruto", 70, 100);
            Warrior warriorAttacked = new Warrior("Naruto", 10, 50);

            //Act
            warriorAttacker.Attack(warriorAttacked);

            //Assert
            Assert.AreEqual(0, warriorAttacked.HP);
        }

        [Test]
        public void WarriorAttackMethodShouldDecreaseEnemysHealth()
        {
            //Arrange
            Warrior warriorAttacker = new Warrior("Naruto", 10, 100);
            Warrior warriorAttacked = new Warrior("Naruto", 10, 50);

            //Act
            warriorAttacker.Attack(warriorAttacked);

            //Assert
            Assert.AreEqual(40, warriorAttacked.HP);
        }
    }
}