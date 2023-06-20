using StackОfStrings;

namespace CustomStack
{
    public class StartUp
    {
        static void Main()
        {
            StackOfStrings stack = new StackOfStrings();
            Console.WriteLine(stack.IsEmpty());

            stack.AddRange(new string[] { "1", "2", "3" });

            Console.WriteLine(string.Join(", ", stack));
        }
    }
}