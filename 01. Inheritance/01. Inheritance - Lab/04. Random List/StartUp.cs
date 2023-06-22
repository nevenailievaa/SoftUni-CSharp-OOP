namespace CustomRandomList
{
    public class StartUp
    {
        static void Main()
        {
            RandomList randomList = new RandomList();
            randomList.Add("a");
            randomList.Add("b");
            randomList.Add("c");
            randomList.Add("d");

            Console.WriteLine("The removed random value is:");
            Console.WriteLine(randomList.RandomString());

            Console.WriteLine(String.Join(", ", randomList));
        }
    }
}