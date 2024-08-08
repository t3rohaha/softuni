namespace InfluencerManagerApp.Models.Influencers;

public class BusinessInfluencer : Influencer
{
    private const double ENGAGEMENT_RATE = 3;
    private const double FACTOR = 0.15;

    public BusinessInfluencer(string username, int followers) : base(username, followers, ENGAGEMENT_RATE)
    {
    }

    public override int CalculateCampaignPrice()
    {
        return (int)(base.Followers * base.EngagementRate * FACTOR);
    }
}
