namespace More.Observer.P00_ChatGPTExample;
public class Subject : ISubject
{
    private string _name;
    private string _state;
    private List<IObserver> _observers = new List<IObserver>();

    public Subject(string name)
    {
        _name = name;
        _state = $"{name}: Initial state";
        _observers = new List<IObserver>();
    }

    public void UpdateState(string state)
    {
        _state = $"{_name}: {state}";
        Notify();
    }

    public void Attach(IObserver observer)
    {
        _observers.Add(observer);
    }

    public void Detach(IObserver observer)
    {
        _observers.Remove(observer);
    }

    public void Notify()
    {
        foreach (var o in _observers)
            o.Notify(_state);
    }
}
