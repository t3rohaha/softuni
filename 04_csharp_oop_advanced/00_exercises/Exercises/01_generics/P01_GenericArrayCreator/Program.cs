namespace Generics.P01_GenericArrayCreator;
public class Program
{
    public static void Main()
    {
        string[] strings = ArrayCreator.Create(5, "Pesho");
        Console.WriteLine(string.Join(", ", strings));

        int[] integers = ArrayCreator.Create(10, 33);
        Console.WriteLine(string.Join(", ", integers));
    }
}
