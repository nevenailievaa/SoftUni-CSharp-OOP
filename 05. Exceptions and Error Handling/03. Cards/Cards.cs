using System.Text;

//Input
string[] allCards = Console.ReadLine().Split(", ");

//Action
List<Card> cards = new List<Card>();

foreach (string card in allCards)
{
    string[] currentCardInfo = card.Split(" ", StringSplitOptions.RemoveEmptyEntries);

    try
    {
        string face = currentCardInfo[0];
        char suit = char.Parse(currentCardInfo[1]);

        Card currentCard = new Card(face, suit);
        cards.Add(currentCard);
    }
    catch (InvalidCardException ex)
    {
        Console.WriteLine(ex.Message);
    }
    catch
    {
        Console.WriteLine("Invalid card!");
    }
}

//Output
Console.WriteLine(string.Join(" ", cards));


//Class Card
class Card
{
    //Fields
    private string face;
    private char suit;

    //Constructor
    public Card(string face, char suit)
    {
        Face = face;
        Suit = suit;
    }

    //Properties
    private string Face
    {
        get => face;

        set => face = FaceChecker(value);
    }

    private char Suit
    {
        get => suit;

        set => suit = SuitChecker(value);
    }

    //Methods
    private string FaceChecker(string value)
    {
        if (value == "10")
        {
            return value;
        }

        if (value.Length != 1)
        {
            throw new InvalidCardException(InvalidCardException.InvalidCardExceptionMessage);
        }

        if (char.IsDigit(Convert.ToChar(value)))
        {
            return value;
        }

        if (!char.IsLetter(Convert.ToChar(value)))
        {
            throw new InvalidCardException(InvalidCardException.InvalidCardExceptionMessage);
        }

        if (value == "J" || value == "Q" || value == "K" || value == "A")
        {
            return value;
        }
        else
        {
            throw new InvalidCardException(InvalidCardException.InvalidCardExceptionMessage);
        }
    }

    private char SuitChecker(char value)
    {
        switch (value)
        {
            case 'S':
                return '\u2660';
            case 'H':
                return '\u2665';
            case 'D':
                return '\u2666';
            case 'C':
                return '\u2663';
            default:
                throw new InvalidCardException(InvalidCardException.InvalidCardExceptionMessage);
        }
    }

    public override string ToString()
    {
        return $"[{Face}{Suit}]";
    }
}

internal class InvalidCardException : Exception
{
    public const string InvalidCardExceptionMessage = "Invalid card!";

    public InvalidCardException(string invalidCardExceptionMessage) : base(invalidCardExceptionMessage) { }
}