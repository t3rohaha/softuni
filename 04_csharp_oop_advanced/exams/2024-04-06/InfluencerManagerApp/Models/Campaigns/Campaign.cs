using InfluencerManagerApp.Models.Contracts;
using InfluencerManagerApp.Utilities.Messages;

namespace InfluencerManagerApp.Models.Campaigns;

public abstract class Campaign : ICampaign
{
    private string _brand;
    private double _budget;
    private List<string> _contributors;

    #nullable disable
    public Campaign(string brand, double budget)
    {
        this.Brand = brand;
        this.Budget = budget;
        _contributors = new List<string>();
    }
    #nullable enable

    public string Brand
    {
        get => _brand;

        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(ExceptionMessages.BrandIsRequired);
            }

            _brand = value;
        }
    }

    public double Budget
    {
        get => _budget;

        private set 
        {
            _budget = value;
        }
    }

    public IReadOnlyCollection<string> Contributors 
    {
        get => _contributors.AsReadOnly();
    }

    public void Engage(IInfluencer influencer)
    {
        _contributors.Add(influencer.Username);
        this.Budget -= influencer.CalculateCampaignPrice();
    }

    public void Gain(double amount)
    {
        this.Budget += amount;
    }

    public override string ToString()
    {
        return $"{this.GetType().Name} - Brand: {this.Brand}, Budget: {this.Budget}, Contributors: {_contributors.Count()}";
    }
}
