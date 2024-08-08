using InfluencerManagerApp.Core;
using InfluencerManagerApp.Models.Contracts;
using InfluencerManagerApp.Repositories.Contracts;
using Moq;

namespace InfluencerManagerApp.Tests.Core;

public class ControllerTests
{
    private Mock<IRepository<IInfluencer>> _influencers;
    private Mock<IRepository<ICampaign>> _campaigns;

    public ControllerTests()
    {
        _influencers = new Mock<IRepository<IInfluencer>>();
        _campaigns = new Mock<IRepository<ICampaign>>();
    }

    [Fact]
    public void ApplicationReport_NoInfluencers_ShouldReturnAppropriateMessage()
    {
        _influencers.Setup(x => x.Models).Returns(new List<IInfluencer>());

        var controller = new Controller(_influencers.Object, _campaigns.Object);

        var expected = "There are no influencers registered!";
        var actual = controller.ApplicationReport();

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void ApplicationReport_ShouldReturnAppropriateMessage()
    {
        _influencers.Setup(x => x.Models).Returns(InfluencerMocks());
        _campaigns.Setup(x => x.Models).Returns(CampaignMocks());

        var controller = new Controller(_influencers.Object, _campaigns.Object);

        var expected = string.Join("\n", [
            "drogba11 - Followers: 4000000, Total Income: 4000",
            "Active Campaigns:",
            "--ProductCampaign - Brand: KFC, Budget: 1000000, Contributors: 1",
            "--ProductCampaign - Brand: McDonalds, Budget: 1000000, Contributors: 1",
            "terry26 - Followers: 3000000, Total Income: 3000",
            "Active Campaigns:",
            "--ProductCampaign - Brand: Casio, Budget: 1000000, Contributors: 1",
            "--ProductCampaign - Brand: Puma, Budget: 1000000, Contributors: 1",
            "lampard8 - Followers: 2000000, Total Income: 2000",
            "Active Campaigns:",
            "--ProductCampaign - Brand: Adidas, Budget: 1000000, Contributors: 1",
            "--ProductCampaign - Brand: Nike, Budget: 1000000, Contributors: 1",
        ]);

        var actual = controller.ApplicationReport();

        Assert.Equal(expected, actual);
    }

    private ICampaign[] CampaignMocks()
    {
        var m1 = new Mock<ICampaign>();
        var m2 = new Mock<ICampaign>();
        var m3 = new Mock<ICampaign>();
        var m4 = new Mock<ICampaign>();
        var m5 = new Mock<ICampaign>();
        var m6 = new Mock<ICampaign>();

        m1.Setup(x => x.Brand).Returns("Adidas");
        m2.Setup(x => x.Brand).Returns("Nike");
        m3.Setup(x => x.Brand).Returns("Puma");
        m4.Setup(x => x.Brand).Returns("Casio");
        m5.Setup(x => x.Brand).Returns("McDonalds");
        m6.Setup(x => x.Brand).Returns("KFC");

        m1.Setup(x => x.ToString()).Returns("ProductCampaign - Brand: Adidas, Budget: 1000000, Contributors: 1");
        m2.Setup(x => x.ToString()).Returns("ProductCampaign - Brand: Nike, Budget: 1000000, Contributors: 1");
        m3.Setup(x => x.ToString()).Returns("ProductCampaign - Brand: Puma, Budget: 1000000, Contributors: 1");
        m4.Setup(x => x.ToString()).Returns("ProductCampaign - Brand: Casio, Budget: 1000000, Contributors: 1");
        m5.Setup(x => x.ToString()).Returns("ProductCampaign - Brand: McDonalds, Budget: 1000000, Contributors: 1");
        m6.Setup(x => x.ToString()).Returns("ProductCampaign - Brand: KFC, Budget: 1000000, Contributors: 1");

        return [m1.Object, m2.Object, m3.Object, m4.Object, m5.Object, m6.Object];
    }

    private IInfluencer[] InfluencerMocks()
    {
        var m1 = new Mock<IInfluencer>();
        var m2 = new Mock<IInfluencer>();
        var m3 = new Mock<IInfluencer>();

        m1.Setup(x => x.Income).Returns(2_000);
        m2.Setup(x => x.Income).Returns(3_000);
        m3.Setup(x => x.Income).Returns(4_000);

        m1.Setup(x => x.Followers).Returns(2_000_000);
        m2.Setup(x => x.Followers).Returns(3_000_000);
        m3.Setup(x => x.Followers).Returns(4_000_000);

        m1.Setup(x => x.Participations).Returns(["Adidas", "Nike"]);
        m2.Setup(x => x.Participations).Returns(["Puma", "Casio"]);
        m3.Setup(x => x.Participations).Returns(["McDonalds", "KFC"]);

        m1.Setup(x => x.ToString()).Returns("lampard8 - Followers: 2000000, Total Income: 2000");
        m2.Setup(x => x.ToString()).Returns("terry26 - Followers: 3000000, Total Income: 3000");
        m3.Setup(x => x.ToString()).Returns("drogba11 - Followers: 4000000, Total Income: 4000");

        return [m1.Object, m2.Object, m3.Object];
    }
}