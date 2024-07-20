namespace More.ChainOfResponsibility.P01_Log.Models;
public class WarningLogHandler : LogHandler
{
    public override void Handle(string message, string severity)
    {
        if (severity == "warning")
        {
            Console.WriteLine($"Warning: {message}");
        }
        else if (base.next is not null)
        {
            base.next.Handle(message, severity);
        }
    }
}
