using ReflectionAndAttributes.P00_Stealer.Models;

namespace ReflectionAndAttributes.P00_Stealer;
public class Program
{
    public static void Main()
    {
        var spy = new Spy();
        var fieldInfo = spy.StealFieldInfo(typeof(Hacker).FullName!, "username", "_password");
        Console.WriteLine(fieldInfo);

        var accessModifiers = spy.AnalyzeAccessModifiers(typeof(Hacker).FullName!);
        Console.WriteLine(accessModifiers);

        var privateMethods = spy.RevealPrivateMethods(typeof(Hacker).FullName!);
        Console.WriteLine(privateMethods);

        var gettersAndSetters = spy.CollectGettersAndSetters(typeof(Hacker).FullName!);
        Console.WriteLine(gettersAndSetters);
    }
}