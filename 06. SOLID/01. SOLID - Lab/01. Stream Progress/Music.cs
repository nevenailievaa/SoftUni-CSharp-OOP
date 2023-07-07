namespace StreamProgress;

public class Music : File
{
    //Constructor
    public Music(string artist, string album, int length, int bytesSent) :base(artist, length, bytesSent)
    {
        this.Artist = artist;
        this.Album = album;
    }

    //Properties
    public string Artist { get; }
    public string Album { get; }
}
