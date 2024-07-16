namespace SOLID.P04_Recharge.Models;
public abstract class Worker
{
    public Worker(string id)
    {
        Id = id;
        WorkingHours = 0;
    }

    public string Id { get; }
    public int WorkingHours { get; private set; }

    public virtual void Work(int hours)
    {
        WorkingHours += hours;
    }
}