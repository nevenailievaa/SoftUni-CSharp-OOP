using Raiding.Models.Interfaces;

namespace Raiding.Factories.Interfaces;

public interface IHeroFactory
{
    IHero CreateHero(string type, string name);
}