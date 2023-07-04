namespace Raiding.Core;

using Interfaces;
using Raiding.Factories.Interfaces;
using Raiding.IO.Interfaces;
using Raiding.Models.Interfaces;

public class Engine : IEngine
{
    //Fields
    private readonly IReader reader;
    private readonly IWriter writer;
    private readonly IHeroFactory heroFactory;

    private ICollection<IHero> heroes;

    //Constructor
    public Engine(IReader reader, IWriter writer, IHeroFactory heroFactory)
    {
        this.reader = reader;
        this.writer = writer;
        this.heroFactory = heroFactory;
        heroes = new List<IHero>();
    }

    //Methods
    public void Run()
    {
         //Input
         int heroesCount = int.Parse(reader.ReadLine());

        //Heroes
        for (int i = 0; i < heroesCount; i++)
        {
            string name = reader.ReadLine();
            string type = reader.ReadLine();

            try
            {
                IHero currentHero = heroFactory.CreateHero(type, name);
                heroes.Add(currentHero);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                i--;
            }
        }

        //Boss
        int bossPower = int.Parse(reader.ReadLine());

        //Heroes Cast Ability
        int heroesPowerSum = 0;

        foreach (IHero hero in heroes)
        {
            heroesPowerSum += hero.Power;
            Console.WriteLine(hero.CastAbility());
        }

        //Output
        if (heroesPowerSum >= bossPower)
        {
            writer.WriteLine("Victory!");
        }
        else
        {
            writer.WriteLine("Defeat...");
        }
    }
}