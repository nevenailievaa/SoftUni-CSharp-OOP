//Action
try
{
    //Input
    int inputNumber = int.Parse(Console.ReadLine());

	if (inputNumber < 0)
	{
		throw new ArgumentOutOfRangeException(nameof(inputNumber), "Invalid number.");
	}

    Console.WriteLine(Math.Sqrt(inputNumber));
}
catch (ArgumentOutOfRangeException ex)
{
	Console.WriteLine("Invalid number.");
}
finally
{
	Console.WriteLine("Goodbye.");
}