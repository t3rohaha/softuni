namespace More.Observer.P00_ChatGPTExample;
public class Observer : IObserver
{
    private string _name;

    public Observer(string name)
    {
        _name = name;
    }

    public void Notify(string message)
    {
        Console.WriteLine($"{_name} recieved notification: \"{message}\"");
    }
}