using Raiding.Core;
using Raiding.Core.Interfaces;
using Raiding.Factories;
using Raiding.IO;

IEngine engine = new Engine(new ConsoleReader(), new ConsoleWriter(), new HeroFactory());
engine.Run();