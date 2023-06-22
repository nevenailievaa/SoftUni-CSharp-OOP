namespace Animals;

public class Kitten : Cat
{
    //Constants
    private const string kittenGender = "Female";

    //Constructor
    public Kitten(string name, int age) : base(name, age, kittenGender) { }

    //Method
    public override string ProduceSound() => "Meow";
}
