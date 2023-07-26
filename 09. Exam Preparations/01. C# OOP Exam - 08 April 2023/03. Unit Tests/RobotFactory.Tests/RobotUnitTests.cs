using NUnit.Framework;

namespace RobotFactory.Tests
{
    public class Tests
    {
        //Fields
        private Robot robot;

        //Tests
        [SetUp]
        public void Setup()
        {
            robot = new Robot("Samsung", 1999.99, 1);
        }

        [Test]
        public void RobotConstructorShouldInitializeCorrectly()
        {
            //Assert
            Assert.IsNotNull(robot);
            Assert.IsNotNull(robot.Supplements);
            Assert.AreEqual("Samsung", robot.Model);
            Assert.AreEqual(1999.99, robot.Price);
            Assert.AreEqual(1, robot.InterfaceStandard);
        }

        [Test]
        public void RobotToStringMethodShouldWorkProperly()
        {
            //Assert
            Assert.AreEqual(robot.ToString(), $"Robot model: {robot.Model} IS: {robot.InterfaceStandard}, Price: {robot.Price:f2}");
        }
    }
}