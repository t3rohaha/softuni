namespace More.ChainOfResponsibility.P00_Support.Models;
public class ExpertSupportHandler : SupportHandler
{
    public override void Handle(string issue)
    {
        if (issue == "expert")
        {
            Console.WriteLine("ExpertSupportHandler: Handling expert issue...");
        }
        else if (this.next != null)
        {
            this.next.Handle(issue);
        }
        else
        {
            Console.WriteLine("No handler available for this issue.");
        }
    }
}