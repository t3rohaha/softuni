using System.Text;
using InfluencerManagerApp.Core.Contracts;
using InfluencerManagerApp.Models.Campaigns;
using InfluencerManagerApp.Models.Contracts;
using InfluencerManagerApp.Models.Influencers;
using InfluencerManagerApp.Repositories.Contracts;
using InfluencerManagerApp.Utilities.Messages;

namespace InfluencerManagerApp.Core;

public class Controller : IController
{
    private IRepository<IInfluencer> _influencers;
    private IRepository<ICampaign> _campaigns;

    public Controller(IRepository<IInfluencer> influencers, IRepository<ICampaign> campaigns)
    {
        _influencers = influencers;
        _campaigns = campaigns;
    }

    public string ApplicationReport()
    {
        var influencers = _influencers.Models
            .OrderByDescending(x => x.Income)
            .ThenByDescending(x => x.Followers);

        if (!influencers.Any())
        {
            return "There are no influencers registered!";
        }

        var report = new StringBuilder();

        foreach (var i in influencers)
        {
            report.AppendLine(i.ToString());

            var campaigns = _campaigns.Models
                .Where(x => i.Participations.Contains(x.Brand))
                .OrderBy(x => x.Brand);

            if (!campaigns.Any())
            {
                continue;
            }

            report.AppendLine("Active Campaigns:");

            foreach (var c in campaigns)
            {
                report.AppendLine($"--{c.ToString()}");
            }
        }

        return report.ToString().Trim();
    }

    public string AttractInfluencer(string brand, string username)
    {
        var influencer = _influencers.FindByName(username);
 
        var campaign = _campaigns.FindByName(brand);

        if (influencer is null)
        {
            return string.Format(OutputMessages.InfluencerNotFound, _influencers.GetType().Name, username);
        }

        if (campaign is null)
        {
            return string.Format(OutputMessages.CampaignNotFound, brand);
        }

        if (campaign.Contributors.Any(x => x == influencer.Username))
        {
            return string.Format(OutputMessages.InfluencerAlreadyEngaged, username, brand);
        }

        if (!Compatible(influencer, campaign))
        {
            return string.Format(OutputMessages.InfluencerNotEligibleForCampaign, username, brand);
        }

        if (influencer.CalculateCampaignPrice() > campaign.Budget)
        {
            return string.Format(OutputMessages.UnsufficientBudget, brand, username);
        }

        influencer.EnrollCampaign(brand);

        influencer.EarnFee(influencer.CalculateCampaignPrice());

        campaign.Engage(influencer);

        return string.Format(OutputMessages.InfluencerAttractedSuccessfully, username, brand);
    }

    public string BeginCampaign(string typeName, string brand)
    {
        ICampaign campaign;

        if (typeName == nameof(ProductCampaign))
        {
            campaign = new ProductCampaign(brand);
        }
        else if (typeName == nameof(ServiceCampaign))
        {
            campaign = new ServiceCampaign(brand);
        }
        else
        {
            return string.Format(OutputMessages.CampaignTypeIsNotValid, typeName);
        }

        if (_campaigns.Models.Any(x => x.Brand == brand))
        {
            return string.Format(OutputMessages.CampaignDuplicated, brand);
        }

        _campaigns.AddModel(campaign);

        return string.Format(OutputMessages.CampaignStartedSuccessfully, brand, typeName);
    }

    public string CloseCampaign(string brand)
    {
        var campaign = _campaigns.FindByName(brand);

        if (campaign is null)
        {
            return OutputMessages.InvalidCampaignToClose;
        }

        if (campaign.Budget <= 10_000)
        {
            return string.Format(OutputMessages.CampaignCannotBeClosed, brand);
        }

        foreach (var username in campaign.Contributors)
        {
            var influencer = _influencers.FindByName(username);
            influencer.EarnFee(2_000);
            influencer.EndParticipation(brand);
        }

        _campaigns.RemoveModel(campaign);

        return string.Format(OutputMessages.CampaignClosedSuccessfully, brand);
    }

    public string ConcludeAppContract(string username)
    {
        var influencer = _influencers.FindByName(username);

        if (influencer is null)
        {
            return string.Format(OutputMessages.InfluencerNotSigned, username);
        }

        if (influencer.Participations.Any())
        {
            return string.Format(OutputMessages.InfluencerHasActiveParticipations, username);
        }

        _influencers.RemoveModel(influencer);

        return string.Format(OutputMessages.ContractConcludedSuccessfully, username);
    }

    public string FundCampaign(string brand, double amount)
    {
        var campaign = _campaigns.FindByName(brand);

        if (campaign is null)
        {
            return OutputMessages.InvalidCampaignToFund;
        }

        if (amount <= 0)
        {
            return OutputMessages.NotPositiveFundingAmount;
        }

        campaign.Gain(amount);

        return string.Format(OutputMessages.CampaignFundedSuccessfully, brand, amount);
    }

    public string RegisterInfluencer(string typeName, string username, int followers)
    {
        IInfluencer influencer;

        if (typeName == nameof(BusinessInfluencer))
        {
            influencer = new BusinessInfluencer(username, followers);
        }
        else if (typeName == nameof(FashionInfluencer))
        {
            influencer = new FashionInfluencer(username, followers);
        }
        else if (typeName == nameof(BloggerInfluencer))
        {
            influencer = new BloggerInfluencer(username, followers);
        }
        else
        {
            return string.Format(OutputMessages.InfluencerInvalidType, typeName);
        }

        if (_influencers.Models.Any(x => x.Username == username))
        {
            return string.Format(OutputMessages.UsernameIsRegistered, username, _influencers.GetType().Name);
        }

        _influencers.AddModel(influencer);

        return string.Format(OutputMessages.InfluencerRegisteredSuccessfully, username);
    }

    private bool Compatible(IInfluencer influencer, ICampaign campaign)
    {
        var productCompatibility = new string[]
        {
            nameof(BusinessInfluencer),
            nameof(FashionInfluencer)
        };

        var serviceCompatibility = new string[]
        {
            nameof(BusinessInfluencer),
            nameof(BloggerInfluencer)
        };

        var influencerType = influencer.GetType().Name;
        var campaignType = campaign!.GetType().Name;

        if (campaignType == nameof(ProductCampaign))
        {
            if (productCompatibility.Contains(influencerType))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else if (campaignType == nameof(ServiceCampaign))
        {
            if (serviceCompatibility.Contains(influencerType))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        return false;
    }
}
