namespace Events.P00_MSDNExample;
public class Publisher
{
    public event EventHandler? EventHandler;

    protected virtual void OnRaiseCustomEvent(EventArgs e)
    {
        // Make temp copy to avoid race conditions if the last subscriber
        // unsubscribes after the null check.
        var eventHandler = this.EventHandler;

        if (eventHandler != null)
        {
            eventHandler(this, e);
        }
    }

    public void DoSomething()
    {
        Console.WriteLine("Publisher does something...");
        this.OnRaiseCustomEvent(new EventArgs());
    }
}