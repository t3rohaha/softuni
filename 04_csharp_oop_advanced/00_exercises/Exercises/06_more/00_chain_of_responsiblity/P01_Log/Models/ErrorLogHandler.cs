namespace More.ChainOfResponsibility.P01_Log.Models;
public class ErrorLogHandler : LogHandler
{
    public override void Handle(string message, string severity)
    {
        if (severity == "error")
        {
            Console.WriteLine($"Error: {message}");
        }
        else if (base.next is not null)
        {
            base.next.Handle(message, severity);
        }
        else
        {
            Console.WriteLine("Invalid severity!");
        }
    }
}
