//Action
List<int> validNumbers = new List<int>();

while (validNumbers.Count < 10)
{
    try
	{
        int number = int.Parse(Console.ReadLine());

        if (number <= 1 || number >= 100)
		{
			int lastNumber = validNumbers.LastOrDefault() == 0 ? 1 : validNumbers.LastOrDefault();

			throw new ArgumentOutOfRangeException("", $"Your number is not in range {lastNumber} - 100!");
        }
		else if (validNumbers.Count == 0)
		{
            validNumbers.Add(number);
        }
		else if (validNumbers.LastOrDefault() < number)
		{
            validNumbers.Add(number);
        }
		else
		{
            throw new ArgumentOutOfRangeException("", $"Your number is not in range {validNumbers[validNumbers.Count-1]} - 100!");
        }
    }
	catch (FormatException ex)
	{
		Console.WriteLine("Invalid Number!");
	}
	catch (ArgumentOutOfRangeException ex)
	{
		Console.WriteLine(ex.Message);
	}
}

//Output
Console.WriteLine(String.Join(", ", validNumbers));