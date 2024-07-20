using More.ChainOfResponsibility.P00_Support.Models;

namespace More.ChainOfResponsibility.P00_Support;
public class Program
{
    public static void Main()
    {
        var basic = new BasicSupportHandler();
        var advanced = new AdvancedSupportHandler();
        var expert = new ExpertSupportHandler();

        basic.SetNext(advanced);
        advanced.SetNext(expert);

        basic.Handle("basic");
        basic.Handle("advanced");
        basic.Handle("expert");
        basic.Handle("unknown");
    }
}