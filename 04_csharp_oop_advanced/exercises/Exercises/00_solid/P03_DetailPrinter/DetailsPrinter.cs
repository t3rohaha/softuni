namespace SOLID.P03_DetailPrinter;
public class DetailsPrinter
{
    private IList<Employee> _employees;

    public DetailsPrinter(IList<Employee> employees)
    {
        _employees = employees;
    }

    public void PrintDetails()
    {
        foreach (var e in _employees)
            Console.WriteLine(e.GetDetails());
    }
}