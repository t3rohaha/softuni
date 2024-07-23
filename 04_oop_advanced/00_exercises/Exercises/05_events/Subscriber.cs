namespace Events.P00_MSDNExample;
public class Subscriber
{
    public Subscriber(Publisher publisher)
    {
        publisher.EventHandler += HandleEvent;
    }

    void HandleEvent(object? sender, EventArgs e)
    {
        Console.WriteLine("Subscriber handles event...");
    }
}