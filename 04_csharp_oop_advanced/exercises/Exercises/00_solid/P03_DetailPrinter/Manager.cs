using System.Text;

namespace SOLID.P03_DetailPrinter;
public class Manager : Employee
{
    public Manager(string name, ICollection<string> documents) : base(name)
    {
        Documents = new List<string>(documents);
    }

    public IReadOnlyCollection<string> Documents { get; private set; }

    public override string GetDetails()
    {
        var result = new StringBuilder();

        result.AppendLine(base.GetDetails());

        foreach (var d in Documents)
            result.AppendLine($"    {d}");

        return result.ToString();
    }
}