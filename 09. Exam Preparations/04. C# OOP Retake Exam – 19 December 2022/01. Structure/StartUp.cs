namespace UniversityCompetition
{
    using UniversityCompetition.Core;
    using UniversityCompetition.Core.Contracts;

    public class StartUp
    {
        static void Main()
        {
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}
