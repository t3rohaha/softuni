using InfluencerManagerApp.Core;
using InfluencerManagerApp.Core.Contracts;
using InfluencerManagerApp.IO;
using InfluencerManagerApp.Repositories;

namespace InfluencerManagerApp;

public class StartUp
{
    static void Main(string[] args)
    {
        var engine = ConfigureEngine();
        engine.Run();
    }

    static IEngine ConfigureEngine()
    {
        return new Engine
        (
            new Reader(),
            new Writer(),
            new Controller
            (
                new InfluencerRepository(),
                new CampaignRepository()
            )
        );
    }
}