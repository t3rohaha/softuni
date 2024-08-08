using InfluencerManagerApp.IO.Contracts;

namespace InfluencerManagerApp.IO;

public class Reader : IReader
{
    public string ReadLine()
    {
        return Console.ReadLine()!;
    }
}
