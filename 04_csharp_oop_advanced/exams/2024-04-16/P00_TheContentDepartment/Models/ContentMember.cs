namespace TheContentDepartment.Models;
public class ContentMember : TeamMember
{
    public ContentMember(string name, string path) : base(name, path)
    {
    }

    protected override string[] ValidPaths => new string[] {"CSharp", "JavaScript", "Python", "Java"};

    public override string ToString()
    {
        return $"{this.Name} - {this.Path} path. Currently working on {this.InProgress.Count} tasks.";
    }
}