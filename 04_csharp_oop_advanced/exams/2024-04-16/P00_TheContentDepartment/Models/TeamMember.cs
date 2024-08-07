using TheContentDepartment.Models.Contracts;
using TheContentDepartment.Utilities.Messages;

namespace TheContentDepartment.Models;
public abstract class TeamMember : ITeamMember
{
    private string _name = "";
    private string _path = "";
    private List<string> _inProgress;

    public TeamMember(string name, string path)
    {
        this.Name = name;
        this.Path = path;
        _inProgress = new List<string>();
    }

    public string Name { get => _name; private set => this.SetName(value); }
    public string Path { get => _path; private set => this.SetPath(value); }
    protected abstract string[] ValidPaths { get; }
    public IReadOnlyCollection<string> InProgress { get => _inProgress.AsReadOnly(); }

    public void FinishTask(string resourceName)
    {
        _inProgress.Remove(resourceName);
    }

    public void WorkOnTask(string resourceName)
    {
        _inProgress.Add(resourceName);
    }

    private void SetName(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException(ExceptionMessages.NameNullOrWhiteSpace);
        _name = value;
    }

    private void SetPath(string value)
    {
        if (!this.ValidPaths.Any(x => x == value))
            throw new ArgumentException(string.Format(ExceptionMessages.PathIncorrect, value));
        _path = value;
    }
}
