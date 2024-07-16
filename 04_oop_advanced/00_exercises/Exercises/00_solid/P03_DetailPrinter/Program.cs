namespace SOLID.P03_DetailPrinter;
public class Program
{
    public static void Main()
    {
        Employee[] employees = [
            new Employee("John Terry"),
            new Employee("Frank Lampard"),
            new Manager("Jose Mourinho", ["tactics.docx", "opposition.docx"])
        ];

        var printer = new DetailsPrinter(employees);

        printer.PrintDetails();
    }
}