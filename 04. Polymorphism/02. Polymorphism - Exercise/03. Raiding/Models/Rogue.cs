using Raiding.Models.Abstract_Classes;
namespace Raiding.Models;

public class Rogue : Hero
{
    //Fields
    private const int defaultPower = 80;

    //Constructor
    public Rogue(string name) : base(name) { }

    //Properties
    public override int Power => defaultPower;

    //Methods
    public override string CastAbility()
    {
        return base.CastAbility() + $" hit for {Power} damage";
    }
}