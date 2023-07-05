using System.Security.Cryptography.X509Certificates;

//Input
int[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
int exceptionsCaught = 0;

//Action
while (exceptionsCaught < 3)
{
    string[] command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
    string commandType = command[0];

	try
	{
        //Replace Command
		if (commandType == "Replace")
		{
            int index = int.Parse(command[1]);
            int element = int.Parse(command[2]);

            numbers[index] = element;
        }

        //Print Command
        else if (commandType == "Print")
        {
            int startIndex = int.Parse(command[1]);
            int endIndex = int.Parse(command[2]);

            if (startIndex < 0 || startIndex >= numbers.Length || endIndex < 0 || endIndex >= numbers.Length)
            {
                throw new IndexOutOfRangeException();
            }
            for (int i = startIndex; i <= endIndex; i++)
            {
                if (i < endIndex)
                {
                    Console.Write($"{numbers[i]}, ");
                }
                else
                {
                    Console.WriteLine($"{numbers[i]}");
                }
            }
        }

        //Show Command
        else if (commandType == "Show")
        {
            int index = int.Parse(command[1]);
            Console.WriteLine(numbers[index]);
        }
    }
	catch (IndexOutOfRangeException)
	{
		exceptionsCaught++;
        Console.WriteLine("The index does not exist!");
    }
	catch (FormatException)
	{
		exceptionsCaught++;
		Console.WriteLine("The variable is not in the correct format!");
	}
}

//Output
Console.WriteLine(String.Join(", ", numbers));
