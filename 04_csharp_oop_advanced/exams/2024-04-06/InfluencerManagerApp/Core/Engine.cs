using InfluencerManagerApp.Core.Contracts;
using InfluencerManagerApp.IO.Contracts;

namespace InfluencerManagerApp.Core;

public class Engine : IEngine
{
    private IReader _reader;
    private IWriter _writer;
    private IController _controller;

    public Engine(IReader reader, IWriter writer, IController controller)
    {
        _reader = reader;
        _writer = writer;
        _controller = controller;
    }

    public void Run()
    {
        while (true)
        {
            string[] input = _reader.ReadLine().Split();

            try
            {
                string result = string.Empty;

                if (input[0] == "Exit")
                {
                    return;
                }
                else if (input[0] == "RegisterInfluencer")
                {
                    string typeName = input[1];
                    string userName = input[2];
                    int followers = int.Parse(input[3]);

                    result = _controller.RegisterInfluencer(typeName, userName, followers);
                }
                else if (input[0] == "BeginCampaign")
                {
                    string typeName = input[1];
                    string brand = input[2];

                    result = _controller.BeginCampaign(typeName, brand);
                }
                else if (input[0] == "AttractInfluencer")
                {
                    string brand = input[1];
                    string userName = input[2];

                    result = _controller.AttractInfluencer(brand, userName);
                }
                else if (input[0] == "FundCampaign")
                {
                    string brand = input[1];
                    double amount = double.Parse(input[2]);

                    result = _controller.FundCampaign(brand, amount);
                }
                else if (input[0] == "CloseCampaign")
                {
                    string brand = input[1];

                    result = _controller.CloseCampaign(brand);
                }
                else if (input[0] == "ConcludeAppContract")
                {
                    string userName = input[1];

                    result = _controller.ConcludeAppContract(userName);
                }
                else if (input[0] == "ApplicationReport")
                {
                    result = _controller.ApplicationReport();
                }

                _writer.WriteLine(result);
                _writer.WriteText(result);
            }
            catch (Exception ex)
            {
                _writer.WriteLine(ex.Message);
                _writer.WriteText(ex.Message);
            }
        }
    }
}