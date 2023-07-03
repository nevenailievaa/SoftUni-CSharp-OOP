using WildFarm.Core;
using WildFarm.Core.Interfaces;
using WildFarm.Factories;
using WildFarm.IO;

IEngine engine = new Engine(new ConsoleReader(), new ConsoleWriter(), new FoodFactory(), new AnimalFactory());

engine.Run();