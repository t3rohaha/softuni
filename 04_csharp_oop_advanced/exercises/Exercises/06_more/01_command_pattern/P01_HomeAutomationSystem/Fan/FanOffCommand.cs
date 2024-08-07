namespace More.CommandPattern.P01_HomeAutomationSystem.Fan;
public class FanOffCommand : ICommand
{
    private Fan _fan;

    public FanOffCommand(Fan fan)
    {
        _fan = fan;
    }

    public void Execute()
    {
        _fan.Off();
    }
}
