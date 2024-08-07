namespace More.Observer.P00_ChatGPTExample;
public interface ISubject
{
    void Attach(IObserver observer);
    void Detach(IObserver observer);
    void Notify();
}
