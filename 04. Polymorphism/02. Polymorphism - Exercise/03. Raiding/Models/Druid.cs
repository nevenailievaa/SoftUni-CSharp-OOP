using Raiding.Models.Abstract_Classes;

namespace Raiding.Models;

public class Druid : Hero
{
    //Fields
    private const int defaultPower = 80;

    //Constructor
    public Druid(string name) : base(name) { }

    //Properties
    public override int Power => defaultPower;

    //Methods
    public override string CastAbility()
    {
        return base.CastAbility() + $" healed for {Power}";
    }
}