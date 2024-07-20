namespace More.ChainOfResponsibility.P00_Support.Models;
public class AdvancedSupportHandler : SupportHandler
{
    public override void Handle(string issue)
    {
        if (issue == "advanced")
        {
            Console.WriteLine("AdvancedSupportHandler: Handling advanced issue...");
        }
        else if (this.next != null)
        {
            this.next.Handle(issue);
        }
    }
}