namespace LineNumbers;

/*
    Write a program that reads a text file (e. g. input.txt) and inserts line
    numbers in front of each of its lines. The result should be written to
    another text file (e. g. output.txt). Use StreamReader and StreamWriter. 
*/
public class Program
{
    public static void Main()
    {
        var inputPath = @"./01_LineNumbers/Files/input.txt";
        var outputPath = @"./01_LineNumbers/Files/output.txt";

        RewriteFileWithLineNumbersModified(inputPath, outputPath);
    }

    // First approach
    static void RewriteFileWithLineNumbers(string inputPath, string outputPath)
    {
        var inputLines = new List<string>();

        using (var reader = new StreamReader(inputPath))
        {
            while (!reader.EndOfStream)
            {
                inputLines.Add(reader.ReadLine()!);
            }
        }

        using (var writer = new StreamWriter(outputPath))
        {
            for (byte i = 0; i < inputLines.Count; i++)
            {
                writer.WriteLine($"{i:00} {inputLines[i]}");
            }
        }
    }

    // Second approach
    static void RewriteFileWithLineNumbersModified(string inputPath, string outputPath)
    {
        using (var reader = new StreamReader(inputPath))
        using (var writer = new StreamWriter(outputPath))
        {
            byte i = 0;
            while (!reader.EndOfStream)
                writer.WriteLine($"{++i:00} {reader.ReadLine()!}");
        }
    }
}