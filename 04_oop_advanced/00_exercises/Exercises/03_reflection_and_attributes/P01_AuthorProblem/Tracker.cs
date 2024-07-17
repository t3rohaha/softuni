using System.Reflection;

namespace ReflectionAndAttributes.P01_AuthorProblem;
public class Tracker
{
    public void PrintMethodsByAuthor(Type type)
    {
        var methods = type
        .GetMethods(BindingFlags.Instance |
                    BindingFlags.Static |
                    BindingFlags.Public |
                    BindingFlags.NonPublic)
        .Where(m => m.CustomAttributes
            .Any(a => a.AttributeType == typeof(AuthorAttribute)))
        .Select(m => new
        {
            m.Name,
            AuthorAttributes = m.GetCustomAttributes(typeof(AuthorAttribute),
                                                     false)
        });

        foreach (var m in methods)
            foreach (AuthorAttribute a in m.AuthorAttributes)
                Console.WriteLine($"{m.Name} is written by {a.Author}");
    }
}