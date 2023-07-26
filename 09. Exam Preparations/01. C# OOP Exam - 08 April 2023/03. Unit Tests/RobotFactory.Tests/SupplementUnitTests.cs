using NUnit.Framework;
namespace RobotFactory.Tests;

public class SupplementUnitTests
{
    //Fields
    private Supplement supplement;

    //Tests
    [SetUp]
    public void Setup()
    {
        supplement = new Supplement("Pistol", 10);
    }

    [Test]
    public void SupplementConstructorShouldInitializeCorrectly()
    {
        //Assert
        Assert.IsNotNull(supplement);
        Assert.AreEqual(supplement.Name, "Pistol");
        Assert.AreEqual(supplement.InterfaceStandard, 10);
    }

    [Test]
    public void SupplementToStringMethodShouldWorkProperly()
    {
        //Assert
        Assert.AreEqual(supplement.ToString(), $"Supplement: {supplement.Name} IS: {supplement.InterfaceStandard}");
    }
}
