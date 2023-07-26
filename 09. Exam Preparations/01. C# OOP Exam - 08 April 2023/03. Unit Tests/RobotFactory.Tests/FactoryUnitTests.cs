using NUnit.Framework;
using System.Linq;

namespace RobotFactory.Tests
{
    public class FactoryUnitTests
    {
        //Fields
        private Factory factory;

        [SetUp]
        public void Setup()
        {
            factory = new Factory("SpaceX", 10);
        }

        [Test]
        public void ProduceRobot_ValidParams()
        {
            string actualResult = factory.ProduceRobot("Robo-3", 2500, 22);
            string expectedResult = "Produced --> Robot model: Robo-3 IS: 22, Price: 2500.00";

            Assert.AreEqual(expectedResult, actualResult);

        }

        [Test]
        public void ProduceRobot_CheckAdding()
        {
            int expectedCountBeforeProduce = 0;
            int actualCountBeforeProduce = factory.Robots.Count;

            factory.ProduceRobot("Robo-3", 2500, 22);

            int expectedCountAfterProduce = 1;
            int actualCountAfterProduce = factory.Robots.Count;

            Assert.AreEqual(expectedCountBeforeProduce, actualCountBeforeProduce);
            Assert.AreEqual(expectedCountAfterProduce, actualCountAfterProduce);

        }

        [Test]
        public void ProduceRobot_CapacityFull()
        {
            factory = new Factory("SpaceX", 2);

            factory.ProduceRobot("Robo-3", 2500, 22);
            factory.ProduceRobot("Robo-3", 2500, 22);
            string actualResult = factory.ProduceRobot("Robo-3", 2500, 22);
            string expectedResult = "The factory is unable to produce more robots for this production day!";

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void ProduceSupplement_ValidParams()
        {
            factory = new Factory("SpaceX", 2);

            string actualResult = factory.ProduceSupplement("SpecializedArm", 8);

            string expectedResult = "Supplement: SpecializedArm IS: 8";
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void ProduceSupplement_CheckAdding()
        {
            int expectedCountBeforeProduce = 0;
            int actualCountBeforeProduce = factory.Supplements.Count;

            factory.ProduceSupplement("SpecializedArm", 8);

            int expectedCountAfterProduce = 1;
            int actualCountAfterProduce = factory.Supplements.Count;

            Assert.AreEqual(expectedCountBeforeProduce, actualCountBeforeProduce);
            Assert.AreEqual(expectedCountAfterProduce, actualCountAfterProduce);

        }

        [Test]
        public void UpgradeRobot_Successful()
        {
            factory.ProduceRobot("Robo-3", 2500, 22);
            factory.ProduceSupplement("SpecializedArm", 22);

            var actualResult = factory.UpgradeRobot(factory.Robots.FirstOrDefault(), factory.Supplements.FirstOrDefault());

            Assert.IsTrue(actualResult);

        }

        [Test]
        public void UpgradeRobot_AlreadyUpgraded()
        {
            factory.ProduceRobot("Robo-3", 2500, 22);
            factory.ProduceSupplement("SpecializedArm", 22);

            factory.UpgradeRobot(factory.Robots.FirstOrDefault(), factory.Supplements.FirstOrDefault());

            var actualResult = factory.UpgradeRobot(factory.Robots.FirstOrDefault(), factory.Supplements.FirstOrDefault());

            Assert.IsFalse(actualResult);

        }

        [Test]
        public void UpgradeRobot_DifferentStandards()
        {
            factory.ProduceRobot("Robo-3", 2500, 22);
            factory.ProduceSupplement("SpecializedArm", 21);

            var actualResult = factory.UpgradeRobot(factory.Robots.FirstOrDefault(), factory.Supplements.FirstOrDefault());

            Assert.IsFalse(actualResult);

        }

        [Test]
        public void SellRobot_Successful()
        {
            factory.ProduceRobot("Robo-3", 2000, 22);
            factory.ProduceRobot("Robo-3", 2500, 22);
            factory.ProduceRobot("Robo-3", 30000, 22);

            Robot robot = factory.Robots.FirstOrDefault(r => r.Price == 2000);

            var robotSold = factory.SellRobot(2499);

            Assert.AreSame(robot, robotSold);

        }
    }
}