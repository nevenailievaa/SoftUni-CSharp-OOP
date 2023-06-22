namespace Animals;

public class Frog : Animal
{
    //Constructor
    public Frog(string name, int age, string gender) : base(name, age, gender) { }

    //Method
    public override string ProduceSound() => "Ribbit";
}
