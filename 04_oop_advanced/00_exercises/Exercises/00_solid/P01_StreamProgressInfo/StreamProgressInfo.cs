using SOLID.P01_StreamProgressInfo.Interfaces;

namespace SOLID.P01_StreamProgressInfo;
public class StreamProgressInfo
{
    private IStreamable _streamable;

    public StreamProgressInfo(IStreamable streamable)
    {
        _streamable = streamable;
    }

    public int CalculateCurrentPercent()
    {
        return (_streamable.BytesSent * 100) / _streamable.Length;
    }
}