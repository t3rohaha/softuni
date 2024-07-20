namespace More.ChainOfResponsibility.P00_Support;
public abstract class SupportHandler
{
    protected SupportHandler? next;

    public void SetNext(SupportHandler next)
    {
        this.next = next;
    }

    public abstract void Handle(string issue);
}