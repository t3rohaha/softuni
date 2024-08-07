using SOLID.P01_StreamProgressInfo.Interfaces;

namespace SOLID.P01_StreamProgressInfo.Models;
public class File : IStreamable
{
    public File(string name, int length, int bytesSent)
    {
        Name = name;
        Length = length;
        BytesSent = bytesSent;
    }

    public string Name { get; private set; }
    public int Length { get; private set; }
    public int BytesSent { get; private set; }
}