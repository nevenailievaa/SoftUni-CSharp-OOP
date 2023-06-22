namespace Animals;

public class Tomcat : Cat
{
    //Constants
    private const string tomcatGender = "Female";

    //Constructor
    public Tomcat(string name, int age) : base(name, age, tomcatGender) { }

    //Method
    public override string ProduceSound() => "MEOW";
}
