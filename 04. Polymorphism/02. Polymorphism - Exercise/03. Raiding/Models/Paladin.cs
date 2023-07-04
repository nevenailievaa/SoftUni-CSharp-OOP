using Raiding.Models.Abstract_Classes;
namespace Raiding.Models;

public class Paladin : Hero
{
    //Fields
    private const int defaultPower = 100;

    //Constructor
    public Paladin(string name) : base(name) { }

    //Properties
    public override int Power => defaultPower;

    //Methods
    public override string CastAbility()
    {
        return base.CastAbility() + $" healed for {Power}";
    }
}