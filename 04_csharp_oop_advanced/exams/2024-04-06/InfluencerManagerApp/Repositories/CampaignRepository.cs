using InfluencerManagerApp.Models.Contracts;
using InfluencerManagerApp.Repositories.Contracts;

namespace InfluencerManagerApp.Repositories;

public class CampaignRepository : IRepository<ICampaign>
{
    private List<ICampaign> _models;

    public CampaignRepository()
    {
        _models = new List<ICampaign>();
    }

    public IReadOnlyCollection<ICampaign> Models
    {
        get => _models.AsReadOnly();
    }

    public void AddModel(ICampaign model)
    {
        _models.Add(model);
    }

    public ICampaign FindByName(string name)
    {
        return _models.FirstOrDefault(x => x.Brand == name)!;
    }

    public bool RemoveModel(ICampaign model)
    {
        return _models.Remove(model);
    }
}
