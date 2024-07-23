using SOLID.P01_StreamProgressInfo.Interfaces;

namespace SOLID.P01_StreamProgressInfo.Models;
public class Music : IStreamable
{
    public Music(string artist, string album, int length, int bytesSent)
    {
        Artist = artist;
        Album = album;
        Length = length;
        BytesSent = bytesSent;
    }

    public string Artist { get; }
    public string Album { get; }
    public int Length { get; }
    public int BytesSent { get; }
}