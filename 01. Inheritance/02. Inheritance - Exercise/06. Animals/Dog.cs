namespace Animals;

public class Dog : Animal
{
    //Constructor
    public Dog(string name, int age, string gender) : base(name, age, gender) { }

    //Method
    public override string ProduceSound() => "Woof!";
}
