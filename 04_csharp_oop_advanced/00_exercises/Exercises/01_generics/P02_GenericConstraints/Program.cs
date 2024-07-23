namespace Generics.P02_GenericConstraints;
public class Program
{
    public static void Main()
    {
        var scale1 = new Scale<int>(1, 1);
        var scale2 = new Scale<string>("x", "x");
        var scale3 = new Scale<string>("x", "z");

        Console.WriteLine(scale1.GetHeavier());
        Console.WriteLine(scale2.GetHeavier());
        Console.WriteLine(scale3.GetHeavier());
    }
}
