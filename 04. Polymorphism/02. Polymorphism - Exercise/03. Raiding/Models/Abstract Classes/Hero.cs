using Raiding.Models.Interfaces;

namespace Raiding.Models.Abstract_Classes;

public abstract class Hero : IHero
{
    //Constructor
    protected Hero(string name)
    {
        Name = name;
    }

    //Properties
    public string Name { get; private set; }
    public abstract int Power { get; }

    //Methods
    public virtual string CastAbility()
    {
        return $"{this.GetType().Name} - {Name}";
    }
}