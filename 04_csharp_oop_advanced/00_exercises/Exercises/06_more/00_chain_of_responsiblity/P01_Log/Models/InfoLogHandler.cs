namespace More.ChainOfResponsibility.P01_Log.Models;
public class InfoLogHandler : LogHandler
{
    public override void Handle(string message, string severity)
    {
        if (severity == "info")
        {
            Console.WriteLine($"Info: {message}");
        }
        else if (base.next is not null)
        {
            base.next.Handle(message, severity);
        }
    }
}
