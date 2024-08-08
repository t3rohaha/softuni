namespace InfluencerManagerApp.Models.Campaigns;

public class ServiceCampaign : Campaign
{
    private const double BUDGET = 30_000;

    public ServiceCampaign(string brand) : base(brand, BUDGET)
    {
    }
}
