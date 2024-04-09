namespace GenericConstraints;

public class StartUp
{
    static void Main()
    {
        var es1 = new EqualityScale<int>(1, 1);
        Console.WriteLine(es1.AreEqual());

        var es2 = new EqualityScale<string>("x", "x");
        Console.WriteLine(es2.AreEqual());

        var es3 = new EqualityScale<string>("x", "z");
        Console.WriteLine(es3.AreEqual());
    }
}
