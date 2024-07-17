namespace ReflectionAndAttributes.P01_AuthorProblem;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
public class AuthorAttribute : Attribute
{
    public string Author;
    public double Version;  // Named parameter

    public AuthorAttribute(string author)
    {
        Author = author;
        Version = 0.1;      // Default value
    }
}
