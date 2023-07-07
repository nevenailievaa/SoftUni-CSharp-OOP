namespace StreamProgress;

public class Program
{
    static void Main()
    {
        File musicFile = new Music("Maroon 5", "One More Night", 3, 20);
        File pictureFile = new Picture("Cat", 1, 50);

        StreamProgressInfo streamProgressInfo = new StreamProgressInfo(pictureFile);
        Console.WriteLine(streamProgressInfo.CalculateCurrentPercent());
    }
}