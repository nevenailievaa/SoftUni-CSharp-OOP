namespace StreamProgress;

public class File
{
    //Constructor
    public File(string name, int length, int bytesSent)
    {
        Name = name;
        Length = length;
        BytesSent = bytesSent;
    }

    //Properties
    public string Name { get; }
    public int Length { get; set; }

    public int BytesSent { get; set; }
}
