using WildFarm.Factories.Interfaces;
using WildFarm.Models.Animals;
using WildFarm.Models.Interfaces;

namespace WildFarm.Factories;

public class AnimalFactory : IAnimalFactory
{
    public IAnimal CreateAnimal(string[] animalTokens)
    {
        string type = animalTokens[0];
        string name = animalTokens[1];
        double weight = double.Parse(animalTokens[2]);

        if (type == "Owl")
        {
            return new Owl(name, weight, double.Parse(animalTokens[3]));
        }
        else if (type == "Hen")
        {
            return new Hen(name, weight, double.Parse(animalTokens[3]));
        }
        else if (type == "Mouse")
        {
            return new Mouse(name, weight, animalTokens[3]);
        }
        else if (type == "Dog")
        {
            return new Dog(name, weight, animalTokens[3]);
        }
        else if (type == "Cat")
        {
            return new Cat(name, weight, animalTokens[3], animalTokens[4]);
        }
        else if (type == "Tiger")
        {
            return new Tiger(name, weight, animalTokens[3], animalTokens[4]);
        }
        throw new ArgumentException("Invalid animal type!");    
    }
}