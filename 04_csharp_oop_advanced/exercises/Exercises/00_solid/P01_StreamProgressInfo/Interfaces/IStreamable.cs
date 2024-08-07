namespace SOLID.P01_StreamProgressInfo.Interfaces;
public interface IStreamable
{
    int Length { get; }
    int BytesSent { get; }
}