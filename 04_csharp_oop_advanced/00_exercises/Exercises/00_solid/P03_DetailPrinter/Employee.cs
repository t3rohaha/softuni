namespace SOLID.P03_DetailPrinter;
public class Employee
{
    public Employee(string name)
    {
        Name = name;
    }

    public string Name { get; private set; }

    public virtual string GetDetails()
    {
        return Name;
    }
}