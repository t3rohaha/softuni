namespace InfluencerManagerApp.Models.Campaigns;

public class ProductCampaign : Campaign
{
    private const double BUDGET = 60_000;

    public ProductCampaign(string brand) : base(brand, BUDGET)
    {
    }
}
