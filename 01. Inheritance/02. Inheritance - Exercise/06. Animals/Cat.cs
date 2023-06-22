namespace Animals;

public class Cat : Animal
{
    //Constructor
    public Cat(string name, int age, string gender) : base(name, age, gender) {}

    //Method
    public override string ProduceSound() => "Meow meow";
}
