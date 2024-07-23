namespace SOLID.P01_StreamProgressInfo;
public class Program
{
    public static void Main()
    {
        var file = new Models.File("results.txt", 1024, 612);
        var music = new Models.Music("Metallica", "The Black Album", 612_000, 61200);

        var fileProgressInfo = new StreamProgressInfo(file);
        var musicProgressInfo = new StreamProgressInfo(music);

        Console.WriteLine($"{file.Name} progress: {fileProgressInfo.CalculateCurrentPercent()}%");
        Console.WriteLine($"{music.Album} progress: {musicProgressInfo.CalculateCurrentPercent()}%");
    }
}
