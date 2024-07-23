namespace ReflectionAndAttributes.P01_AuthorProblem;

[Author("John")]
[Author("Frank")]
public class TestClass
{
    private const string testConst = "Test Const";

    [Author("Frank")]
    public static void PrintTestMethod()
    {
        Console.WriteLine("Test Method");
    }

    [Author("John")]
    public void PrintTestConst()
    {
        Console.WriteLine(testConst);
    }

    public void PrintTestMethodWithNoAuthor()
    {
        Console.WriteLine("Test Method with no author.");
    }
}
