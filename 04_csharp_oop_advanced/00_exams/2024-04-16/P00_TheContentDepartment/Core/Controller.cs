using System.Text;
using TheContentDepartment.Core.Contracts;
using TheContentDepartment.Models;
using TheContentDepartment.Models.Contracts;
using TheContentDepartment.Repositories;
using TheContentDepartment.Repositories.Contracts;
using TheContentDepartment.Utilities.Messages;

namespace TheContentDepartment.Core;
public class Controller : IController
{
    private IRepository<IResource> _resources;
    private IRepository<ITeamMember> _members;

    public Controller()
    {
        _resources = new ResourceRepository();
        _members = new MemberRepository();
    }

    public string ApproveResource(string resourceName, bool isApprovedByTeamLead)
    {
        var resource = _resources.TakeOne(resourceName);

        if (resource is null)
        {
            throw new Exception("No resource found!");
        }

        if (!resource.IsTested)
        {
            return string.Format(OutputMessages.ResourceNotTested,
                                 resourceName);
        }

        var teamLead = this.GetTeamLead();

        if (!isApprovedByTeamLead)
        {
            resource.Test();

            return string.Format(OutputMessages.ResourceReturned, teamLead.Name,
                                 resourceName);
        }

        resource.Approve();

        teamLead.FinishTask(resourceName);

        return string.Format(OutputMessages.ResourceApproved, teamLead.Name,
                             resourceName);
    }

    public string CreateResource(string resourceType, string resourceName, string path)
    {
        if (!new string[]{"Exam", "Workshop", "Presentation"}.Contains(resourceType))
        {
            return string.Format(OutputMessages.ResourceTypeInvalid,
                                 resourceType);
        }

        var member = _members.Models.FirstOrDefault(x => x.Path == path);

        if (member is null)
        {
            return string.Format(OutputMessages.NoContentMemberAvailable,
                                 resourceName);
        }

        if (member.InProgress.Any(x => x == resourceName))
        {
            return string.Format(OutputMessages.ResourceExists, resourceName);
        }

        IResource? resource = null;

        switch (resourceType)
        {
            case "Exam":
                resource = new Exam(resourceName, member.Name);
                break;
            case "Workshop":
                resource = new Workshop(resourceName, member.Name);
                break;
            case "Presentation":
                resource = new Presentation(resourceName, member.Name);
                break;
        }

        member.WorkOnTask(resourceName);

        _resources.Add(resource!);

        return string.Format(OutputMessages.ResourceCreatedSuccessfully,
                             member.Name, resourceType, resourceName);
    }

    public string DepartmentReport()
    {
        var sb = new StringBuilder();

        var finishedTasks = _resources.Models.Where(x => x.IsApproved);

        sb.AppendLine("Finished Tasks:");

        foreach (var t in finishedTasks)
            sb.AppendLine($"--{t.ToString()}");

        var teamLead = GetTeamLead();

        sb.AppendLine("Team Report:");

        sb.AppendLine($"--{teamLead.ToString()}");

        foreach (var m in _members.Models)
            if (m != teamLead)
                sb.AppendLine($"{m.ToString()}");

        return sb.ToString();
    }

    public string JoinTeam(string memberType, string memberName, string path)
    {
        if (memberType != "TeamLead" && memberType != "ContentMember")
        {
            return string.Format(OutputMessages.MemberTypeInvalid, memberType);
        }

        if (_members.Models.Any(x => x.Path == path))
        {
            return OutputMessages.PositionOccupied;
        }

        if (_members.Models.Any(x => x.Name == memberName))
        {
            return string.Format(OutputMessages.MemberExists, memberName);
        }

        ITeamMember? member = null;

        switch (memberType)
        {
            case "TeamLead":
                member = new TeamLead(memberName, path);
                break;
            case "ContentMember":
                member = new ContentMember(memberName, path);
                break;
        }

        _members.Add(member!);

        return string.Format(OutputMessages.MemberJoinedSuccessfully,
                             memberName);
    }

    public string LogTesting(string memberName)
    {
        var member = _members.TakeOne(memberName);

        if (member is null)
        {
            return OutputMessages.WrongMemberName;
        }

        var resource = _resources.Models
            .Where(x => !x.IsTested && x.Creator == memberName)
            .OrderBy(x => x.Priority)
            .FirstOrDefault();

        if (resource is null)
        {
            return string.Format(OutputMessages.NoResourcesForMember,
                                 memberName);
        }

        member.FinishTask(resource.Name);

        var teamLead = this.GetTeamLead();

        teamLead.WorkOnTask(resource.Name);

        resource.Test();

        return string.Format(OutputMessages.ResourceTested, resource.Name);
    }

    private ITeamMember GetTeamLead()
    {
        var teamLead = _members.Models.FirstOrDefault(x => x.Path == "Master");

        if (teamLead is null)
        {
            throw new Exception("No Team Lead!");
        }

        return teamLead;
    }
}