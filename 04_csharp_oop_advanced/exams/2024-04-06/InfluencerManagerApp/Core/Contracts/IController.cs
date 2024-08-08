namespace InfluencerManagerApp.Core.Contracts;

public interface IController
{
    string ApplicationReport();
    string AttractInfluencer(string brand, string username);
    string BeginCampaign(string typeName, string brand);
    string CloseCampaign(string brand);
    string ConcludeAppContract(string username);
    string FundCampaign(string brand, double amount);
    string RegisterInfluencer(string typeName, string username, int followers);
}