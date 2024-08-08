using InfluencerManagerApp.Models.Contracts;
using InfluencerManagerApp.Repositories.Contracts;

namespace InfluencerManagerApp.Repositories;

public class InfluencerRepository : IRepository<IInfluencer>
{
    private List<IInfluencer> _models;

    public InfluencerRepository()
    {
        _models = new List<IInfluencer>();
    }

    public IReadOnlyCollection<IInfluencer> Models
    {
        get => _models.AsReadOnly();
    }

    public void AddModel(IInfluencer model)
    {
        _models.Add(model);
    }

    public IInfluencer FindByName(string name)
    {
        return _models.FirstOrDefault(x => x.Username == name)!;
    }

    public bool RemoveModel(IInfluencer model)
    {
        return _models.Remove(model);
    }
}