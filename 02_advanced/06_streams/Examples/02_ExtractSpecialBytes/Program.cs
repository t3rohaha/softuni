namespace ExtractSpecialBytes;

public class Program
{
    public static void Main()
    {
        var binaryFilePath = @"./02_ExtractSpecialBytes/Files/example.png";
        var bytesFilePath = @"./02_ExtractSpecialBytes/Files/bytes.txt";
        var outputFilePath = @"./02_ExtractSpecialBytes/Files/output.bin";

        ExtractBytesFromBinaryFile(binaryFilePath, bytesFilePath, outputFilePath);
    }

    static void ExtractBytesFromBinaryFile(string binaryFilePath, string bytesFilePath, string outputFilePath)
    {
        var bytes = File.ReadAllBytes(binaryFilePath);
        var specialBytes = File.ReadAllText(bytesFilePath)
            .Split([' ', '\n', '\r'])
            .Where(x => x != "")
            .Select(byte.Parse)
            .ToArray();
        
        var matchedBytes = new List<byte>();
        foreach (byte b in bytes)
            if (specialBytes.Contains(b)) matchedBytes.Add(b);

        File.WriteAllBytes(outputFilePath, matchedBytes.ToArray());
    }
}