using TheContentDepartment.Models.Contracts;
using TheContentDepartment.Repositories.Contracts;

namespace TheContentDepartment.Repositories;
public class MemberRepository : IRepository<ITeamMember>
{
    private List<ITeamMember> _members;

    public MemberRepository()
    {
        _members = new List<ITeamMember>();
    }

    public IReadOnlyCollection<ITeamMember> Models => _members.AsReadOnly();

    public void Add(ITeamMember model)
    {
        _members.Add(model);
    }

    #nullable disable
    public ITeamMember TakeOne(string modelName)
    {
        return _members.FirstOrDefault(x => x.Name == modelName);
    }
}