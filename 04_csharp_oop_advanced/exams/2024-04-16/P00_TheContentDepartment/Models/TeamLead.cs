namespace TheContentDepartment.Models;
public class TeamLead : TeamMember
{
    public TeamLead(string name, string path) : base(name, path)
    {
    }

    protected override string[] ValidPaths => new string[] {"Master"};

    public override string ToString()
    {
        return $"{this.Name} ({this.GetType().Name}) - Currently working on {this.InProgress.Count} tasks.";
    }
}
