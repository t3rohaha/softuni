namespace AuthorProblem;

public class Program
{
    public static void Main()
    {
        var tracker = new Tracker();
        tracker.PrintMethodsByAuthor(typeof(TestClass));
    }
}
