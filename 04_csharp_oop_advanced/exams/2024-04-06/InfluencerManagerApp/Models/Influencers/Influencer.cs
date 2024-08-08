using InfluencerManagerApp.Models.Contracts;
using InfluencerManagerApp.Utilities.Messages;

namespace InfluencerManagerApp.Models.Influencers;

public abstract class Influencer : IInfluencer
{
    private string _username;
    private int _followers;
    private double _engagementRate;
    private double _income;
    private List<string> _participations;

    #nullable disable
    public Influencer(string username, int followers, double engagementRate)
    {
        this.Username = username;
        this.Followers = followers;
        this.EngagementRate = engagementRate;
        this.Income = 0;
        _participations = new List<string>();
    }
    #nullable enable

    public string Username
    {
        get => _username;

        private set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException(ExceptionMessages.UsernameIsRequired);
            }

            _username = value;
        }
    }

    public int Followers
    {
        get => _followers;
        
        private set 
        {
            if (value < 0)
            {
                throw new ArgumentException(ExceptionMessages.FollowersCountNegative);
            }

            _followers = value;
        }
    }

    public double EngagementRate
    {
        get => _engagementRate;
        
        private set 
        {
            _engagementRate = value;
        }    
    }

    public double Income
    {
        get => _income;
        
        private set
        {
            _income = value;
        }
    }

    public IReadOnlyCollection<string> Participations 
    {
        get => _participations.AsReadOnly();
    }

    public void EarnFee(double amount)
    {
        this.Income += amount;
    }

    public void EndParticipation(string brand)
    {
        _participations.Remove(brand);
    }

    public void EnrollCampaign(string brand)
    {
        _participations.Add(brand);
    }

    public override string ToString()
    {
        return $"{this.Username} - Followers: {this.Followers}, Total Income: {Income}";
    }

    public abstract int CalculateCampaignPrice();
}
