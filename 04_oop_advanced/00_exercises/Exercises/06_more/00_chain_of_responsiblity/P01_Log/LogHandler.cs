namespace More.ChainOfResponsibility.P01_Log;
public abstract class LogHandler
{
    public LogHandler? next;

    public void SetNext(LogHandler next)
    {
        this.next = next;
    }

    public abstract void Handle(string message, string severity);
}
