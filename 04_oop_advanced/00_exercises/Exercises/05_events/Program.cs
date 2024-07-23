namespace Events.P00_MSDNExample;
public class Program
{
    public static void Main()
    {
        var publisher = new Publisher();
        var s1 = new Subscriber(publisher);
        var s2 = new Subscriber(publisher);

        publisher.DoSomething();
    }
}