using SOLID.P04_Recharge.Interfaces;

namespace SOLID.P04_Recharge.Models;
public class Employee : Worker, ISleeper
{
    public Employee(string id) : base(id) { }

    public void Sleep()
    {
        Console.WriteLine($"Employee: {base.Id} sleeps...");
    }
}