namespace InfluencerManagerApp.Models.Influencers;

public class FashionInfluencer : Influencer
{
    private const double ENGAGEMENT_RATE = 4;
    private const double FACTOR = 0.1;

    public FashionInfluencer(string username, int followers) : base(username, followers, ENGAGEMENT_RATE)
    {
    }

    public override int CalculateCampaignPrice()
    {
        return (int)(base.Followers * base.EngagementRate * FACTOR);
    }
}
