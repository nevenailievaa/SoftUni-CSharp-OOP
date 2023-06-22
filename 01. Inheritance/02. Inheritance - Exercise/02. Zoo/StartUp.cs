namespace Zoo
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Snake snake = new Snake("Taipan");
            Bear bear = new Bear("Narla");

            Console.WriteLine(snake.Name);
            Console.WriteLine(bear.Name);
        }
    }
}