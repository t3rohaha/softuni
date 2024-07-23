namespace More.ChainOfResponsibility.P00_Support.Models;
public class BasicSupportHandler : SupportHandler
{
    public override void Handle(string issue)
    {
        if (issue == "basic")
        {
            Console.WriteLine("BasicSupportHandler: Handling basic issue...");
        }
        else if (this.next != null)
        {
            this.next.Handle(issue);
        }
    }
}