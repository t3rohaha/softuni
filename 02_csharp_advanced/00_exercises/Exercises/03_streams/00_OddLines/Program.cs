namespace OddLines;

/*
    Write a program that reads a text file (e. g. input.txt) and writes every
    odd line in another file. Line numbers start from 0.  
*/
public class Program
{
    public static void Main()
    {
        var inputFilePath = @"./00_OddLines/Files/input.txt";
        var outputFilePath = @"./00_OddLines/Files/output.txt";

        ExtractOddLines(inputFilePath, outputFilePath);
    }

    static void ExtractOddLines(string inputFilePath, string outputFilePath)
    {
        string[] lines = File.ReadAllLines(inputFilePath);
        var oddLines = lines.Where((line, index) => index % 2 != 0);

        Console.WriteLine("Writing odd lines...");
        File.WriteAllLines(outputFilePath, oddLines);
        Console.WriteLine("Finished.");
    }
}