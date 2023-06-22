namespace PlayersAndMonsters
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            SoulMaster soulMaster = new SoulMaster("Elza", 100);
            MuseElf museElf = new MuseElf("Fenriria", 10);
            BladeKnight bladeKnight = new BladeKnight("Troy", 30);


            Console.WriteLine($"Username: {soulMaster.Username}, Level: {soulMaster.Level}");
            Console.WriteLine($"Username: {museElf.Username}, Level: {museElf.Level}");
            Console.WriteLine($"Username: {bladeKnight.Username}, Level: {bladeKnight.Level}");
        }
    }
}